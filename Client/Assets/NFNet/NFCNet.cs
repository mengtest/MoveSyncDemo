using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace NFSDK
{
    public enum EConnectError
    {
        eCE_LoseConnect = 0,  			//���Ӷ�ʧ
        eCE_NoNet,					//������
        eCE_LoginOnAnotherDevice,	//�������豸��¼�������ţ�
        eCE_ReadyToMaintain,		//׼����ʼά��
        eCE_Maintaining,			//����ά����
        eCE_ServerLose,             // ��������ʧ
        eCE_ServerHeartBreak,       // ������û�ذ�
    };
    public class ConstDefine
    {
        public static UInt32 NF_PACKET_HEAD_SIZE = 2;
        public static int MAX_PACKET_LEN = 655360;
        public static int MAX_PACKET_POOL_SIZE = 6553600;
    };
    public class ConnectedEventArgs : EventArgs
    {
    }
    public class DisConnectedEventArgs : EventArgs
    {
        public EConnectError eErrorCode;
    }
    public class NFCNet
    {
        public enum State { CONNECTING, DISCONNECTED, CONNECT_FAILED, CONNECTED };
        private static NFCNet _instance = null;
        public static NFCNet Instance()
        {
            if (_instance == null)
            {
                _instance = new NFCNet();
            }
            return _instance;
        }
        public EventHandler<ConnectedEventArgs> OnConnected;
        public EventHandler<DisConnectedEventArgs> OnDisConnected;
        public Action<UInt16, MemoryStream> OnParseMsg;
        public bool NotDispatch { get; set; }

        //when you ready to build a tcp connection, call this method first.
        public bool ready(String ip, UInt16 port)
        {
            if (m_curState != State.DISCONNECTED)
                return false;

            this.ip = ip;
            this.port = port;
            return true;
        }

        public void connect()
        {
            Debug.Log("Connection.connect:" + ip + "     " + port);
            IPEndPoint hostEntry = new IPEndPoint(IPAddress.Parse(ip), port);
            SocketAsyncEventArgs SAEA = new SocketAsyncEventArgs();
            SAEA.RemoteEndPoint = hostEntry;
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SAEA.Completed += new EventHandler<SocketAsyncEventArgs>(Completed_Conneceted);
            m_curState = State.CONNECTING;
            m_socket.Blocking = true;
            m_socket.ConnectAsync(SAEA);
        }
        private void Completed_Conneceted(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    {
                        if (m_socket.Connected)
                        {
                            m_curState = State.CONNECTED;
                            if (OnConnected != null)
                                OnConnected(this, new ConnectedEventArgs());
                            Debug.Log("connected!!!!");
                        }
                        else
                        {
                            m_curState = State.CONNECT_FAILED;
                            Debug.Log("cannot connect!!!!!");
                            Debug.LogError(e.SocketError.ToString());
                        }
                    }
                    break;
            }
        }

        public void shutDown()
        {
            Debug.Log("Connectopm.ShutDown");
            if (m_curState != State.CONNECTED && m_curState != State.CONNECTING)
            {
                Debug.LogFormat("Cannot shut down the socket when the socket is not connected.{0}", m_curState);
                return;
            }
            m_socket.Close();
            m_curState = State.DISCONNECTED;
        }

        public bool isConnected()
        {
            return m_curState == State.CONNECTED;
        }

        public bool isConnecting()
        {
            return m_curState == State.CONNECTING;
        }

        public bool isIdle()
        {
            return m_curState == State.DISCONNECTED;
        }

        public State getState()
        {
            return m_curState;
        }

        public void doUpdate()
        {
            if (m_curState == State.CONNECT_FAILED)
            {
                m_curState = State.DISCONNECTED;
                DisConnectedEventArgs arg = new DisConnectedEventArgs();
                arg.eErrorCode = EConnectError.eCE_LoseConnect;
                if (OnDisConnected != null)
                    OnDisConnected(this, arg);
            }
            else if (m_curState == State.CONNECTED)
            {
                m_socket.Blocking = false;
                sendAllMsgs();
                recvMsgs();
                dispatchMsgs();
            }
        }

        void flush()
        {
            sendAllMsgs();
        }

        void instantSendMsg(MemoryStream stream)
        {
            sendMsg(stream);
        }

        void sendAllMsgs()
        {
            int nReadSize = m_sendPool.ReadSize;
            if (nReadSize <= 0)
                return;

            try {
                int nByteTrans = m_socket.Send(m_sendPool.Buffer, m_sendPool.ReadPos, nReadSize, SocketFlags.None);
                m_sendPool.ReadPos += nByteTrans;
            }
            catch (Exception ex)
            {
                Debug.LogError("sendAllMsgs exp:" + ex.ToString());
            }

            //Debug.LogWarningFormat("Send Data{0}", nByteTrans);

        }

        public static UInt16 ConvertUint16(UInt16 value)
        {
            byte[] temp = BitConverter.GetBytes(value);
            Array.Reverse(temp);
            return BitConverter.ToUInt16(temp, 0);
        }
        public static UInt32 ConvertUint32(UInt32 value)
        {
            byte[] temp = BitConverter.GetBytes(value);
            Array.Reverse(temp);
            return BitConverter.ToUInt32(temp, 0);
        }

        void recvMsgs()
        {
            int len = 0;
            try
            {
                len = m_socket.Receive(m_recvBuf, 0, kBufferSize, SocketFlags.None);
            }
            catch (SocketException ex)
            {
                if (m_socket.Connected == false)
                {
                    Debug.Log("Disconnected from server!!");
                    m_curState = State.DISCONNECTED;
                    DisConnectedEventArgs arg = new DisConnectedEventArgs();
                    arg.eErrorCode = EConnectError.eCE_LoseConnect;
                    if (OnDisConnected != null)
                        OnDisConnected(this, arg);
                }
                if (ex.SocketErrorCode != SocketError.NoData && ex.SocketErrorCode != SocketError.WouldBlock)
                {
                    Debug.LogError(ex);
                    Debug.LogErrorFormat("ErrorCode:{0}", ex.SocketErrorCode);
                }
                return;
            }

            if (m_recvPool.WriteSize < len)
            {
                Debug.LogError("Too much messages, disconnected from server!!");
                if (m_curState != State.DISCONNECTED)
                {
                    shutDown();
                    DisConnectedEventArgs arg = new DisConnectedEventArgs();
                    arg.eErrorCode = EConnectError.eCE_LoseConnect;
                    OnDisConnected(this, arg);
                }
                return;
            }

            m_recvPool.PushData(m_recvBuf, 0, len);
        }

        void dispatchMsgs()
        {
            while (!NotDispatch)
            {
                int nReadSize = m_recvPool.ReadSize;
                int nReadPos = m_recvPool.ReadPos;
                // ��Ϣû�а�ͷ����Ƴ�ѭ��
                if (nReadSize < ConstDefine.NF_PACKET_HEAD_SIZE)
                    break;

                int offset = 0; // ������ͷ��ǩ����       
                UInt16 length = BitConverter.ToUInt16(m_recvPool.Buffer, nReadPos + offset);
                offset += sizeof(UInt16);
                UInt16 nMsgID = BitConverter.ToUInt16(m_recvPool.Buffer, nReadPos + offset);
                offset += sizeof(UInt16);
                // ��Ϣ����û����ȫ���������˳�
                length = (ushort)(ConvertUint16(length)+ ConstDefine.NF_PACKET_HEAD_SIZE);
                nMsgID = ConvertUint16(nMsgID);

                //Debug.LogWarningFormat("RecvData {0} \t {1}", length, nMsgID);
                if (nReadSize < length)
                    break;

                m_recvPool.ReadPos += (int)length;

                //Debug.LogFormat("Recv:{0}", nMsgID);

                nReadPos += (int)(ConstDefine.NF_PACKET_HEAD_SIZE+ ConstDefine.NF_PACKET_HEAD_SIZE);
                length -= (UInt16)(ConstDefine.NF_PACKET_HEAD_SIZE+ ConstDefine.NF_PACKET_HEAD_SIZE);

                var mem = new MemoryStream(m_recvPool.Buffer, nReadPos, (int)length);
                if (OnParseMsg != null)
                    OnParseMsg(nMsgID, mem);

                if (m_curState != State.CONNECTED)
                    break;
                // MemoryStream mem = new MemoryStream(m_recvPool.Buffer, nReadPos, (int)length);
                //NFCNetDispatcher.Instance().dispatchMessage(nMsgID, mem);
            }
        }

        void discardRecvMsgs()
        {
            while (true)
            {
                int nReadSize = m_recvPool.ReadSize;
                int nReadPos = m_recvPool.ReadPos;
                // ��Ϣû�а�ͷ����Ƴ�ѭ��
                if (nReadSize < 6)
                    break;

                int offset = 0; // ������ͷ��ǩ����
                UInt32 length = BitConverter.ToUInt16(m_recvPool.Buffer, nReadPos + offset);
                offset += sizeof(UInt32);
                // ��Ϣ����û����ȫ���������˳�
                if (nReadSize < length)
                    break;

                m_recvPool.ReadPos += (int)length;
            }
        }

        public void sendMsg(MemoryStream stream)
        {
            if (m_sendPool.WriteSize < stream.Length)
            {
                // ���ͳ��������������Ͱ�
                Debug.LogError("SendPool is Full");
                return;
            }
            m_sendPool.PushData(stream.GetBuffer(), 0, (int)stream.Length);
        }

        public void HeartBreak()
        {
            DisConnectedEventArgs arg = new DisConnectedEventArgs();
            arg.eErrorCode = EConnectError.eCE_ServerHeartBreak;
            if (OnDisConnected != null)
                OnDisConnected(this, arg);
        }

        bool hasError()
        {
            return m_socket.Connected == false; ;
        }

        public String ip;
        UInt16 port = 0;
        private static int kPoolSize = ConstDefine.MAX_PACKET_POOL_SIZE;
        private static int kBufferSize = ConstDefine.MAX_PACKET_LEN;
        NFCRingBuffer m_sendPool = new NFCRingBuffer(kPoolSize, kBufferSize);
        NFCRingBuffer m_recvPool = new NFCRingBuffer(kPoolSize, kBufferSize);
        Byte[] m_recvBuf = new Byte[kBufferSize];

        State m_curState = State.DISCONNECTED;
        Socket m_socket;
    };
}