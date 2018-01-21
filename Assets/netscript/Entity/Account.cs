namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public class Account:Entity
    {
        public float lastUpdateTime = 0;
        public delegate void addRoom(string name, string num);
        public Dictionary<string, object> RoomInitData;//用于初始化房间的列表
        public List<Dictionary<string, object>> RoomChangeList=new List<Dictionary<string, object>>();


        public static bool PlayerInRoom = false;//用于确定player的init是因为登入还是
        //public addRoom addroom_fuction;//在hallmanager裏面加 
        public override void __init__()
        {

            if (!PlayerInRoom)//登入
            {
                KBEngine.Event.fireOut("onLoginSuccessfully", new object[] { KBEngineApp.app.entity_uuid, id, this });

            }

         
        }
        public void cellReady()
        {
            Debug.Log("服務器的cell準備好了");
        }

    }
}
