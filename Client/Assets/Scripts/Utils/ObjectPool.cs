﻿/*
 * 对象池
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public class ObjectPool<T> where T : class, new()
    {
        public delegate T CreateFunc();

        //已经创建了多少个
        public int totalCreateCount = 0;

        //
        // Methods
        //
        public T GetObject()
        {
            if (m_objStack.Count > 0)
            {
                T t = m_objStack.Pop();
                if (m_resetAction != null)
                {
                    m_resetAction(t);
                }
                return t;
            }
            return CreateNew();
        }

        public void Init(int poolSize, CreateFunc createFunc = null, Action<T> resetAction = null)
        {
            m_objStack = new Stack<T>();
            m_resetAction = resetAction;
            m_createFunc = createFunc;
            for (int i = 0; i < poolSize; i++)
            {
                T item = CreateNew();
                m_objStack.Push(item);
            }
        }

        public void Store(T obj)
        {
			if (obj == null)
				return;
			if (m_resetAction != null)
				m_resetAction(obj);
            m_objStack.Push(obj);
        }

		// 少用，调用这个池的作用就没有了
		public void Clear() {
			if (m_objStack != null)
				m_objStack.Clear();
		}

		public int Count
		{
			get
			{
				if (m_objStack == null)
					return 0;
				return m_objStack.Count;
			}
		}

		public Stack<T>.Enumerator GetIter() {
			if (m_objStack == null)
				return new Stack<T>.Enumerator();
			return m_objStack.GetEnumerator();
		}

        //  所有生产的对象都在池子里面
        public bool AllInStore()
        {
            return totalCreateCount == Count;
        }

        private T CreateNew()
        {
            totalCreateCount++;
            return (m_createFunc != null) ? m_createFunc() : new T();
        }

        private Stack<T> m_objStack = null;
        private Action<T> m_resetAction = null;
        private CreateFunc m_createFunc = null;
    }
}