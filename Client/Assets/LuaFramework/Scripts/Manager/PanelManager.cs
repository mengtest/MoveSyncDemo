using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LuaInterface;

namespace LuaFramework {
    public class PanelManager : Manager {
        private Transform parent;

        //Transform Parent {
        //    get {
        //        if (parent == null) {
        //            GameObject go = GameObject.FindWithTag("GuiCamera");
        //            if (go != null) parent = go.transform;
        //        }
        //        return parent;
        //    }
        //}

        /// <summary>
        /// 创建面板，请求资源管理器
        /// </summary>
        /// <param name="type"></param>
        public void CreatePanel(string name, LuaFunction func = null)
        {
            string assetName = name + "Panel";
            string abName = name.ToLower() + AppConst.ExtName;
            //if (Parent.FindChild(name) != null) return;

            //ResManager.LoadGameObject(abName, new string[] { assetName }, delegate(UnityEngine.Object[] objs) {
            //    if (objs.Length == 0) return;
            //    GameObject go = objs[0] as GameObject;
            //    if (go == null) return;
            //    go.name = assetName;
            //    go.layer = LayerMask.NameToLayer("Default");
            //    //go.transform.SetParent(Parent);
            //    go.transform.localScale = Vector3.one;
            //    go.transform.localPosition = Vector3.zero;
            //    go.AddComponent<LuaBehaviour>();

            //    if (func != null) func.Call(go);
            //    Debug.LogWarning("CreatePanel::>> " + name + " " + go);
            //});
        }

        /// <summary>
        /// 关闭面板
        /// </summary>
        /// <param name="name"></param>
        public void ClosePanel(string name) {
            var panelName = name + "Panel";
            //var panelObj = Parent.FindChild(panelName);
            //if (panelObj == null) return;
            //Destroy(panelObj.gameObject);
        }
    }
}