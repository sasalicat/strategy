﻿namespace KBEngine
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
        public void addNewUnit(sbyte no,short kind,Dictionary<String,object> skillList, float posx, float posy,long ownerid) {//放置一个新角色
            Debug.Log("type no:" + no.GetType()+" skillList:"+skillList.GetType()+" posx:"+posx.GetType()+" posy"+posy.GetType());
            Dictionary<string, object> arg=new Dictionary<string, object>();
            arg["kind"] = kind;
            arg["skillList"] = skillList["list"];
            arg["position"] = new Vector2(posx, posy);
            arg["no"] = no;
            ((KBWarManager)WarFieldManager.manager).addOrder( KBWarManager.ADD_UNIT, arg);
        }
        public void setMoving(sbyte mov)
        {
            Debug.Log("setmoving中 参数为"+mov);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["moving"] = (mov==1);
            ((KBWarManager)WarFieldManager.manager).addOrder( KBWarManager.CHANGE_MOVING, arg);
        }
        public void setSpeed(float sp)
        {
            Debug.Log("setSpeed中 参数为" + sp);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["speed"] = sp;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.CHANGE_SPEED, arg);
        }
        public void setDirect(Vector2 dir)
        {
            Debug.Log("setDirect中 参数为" + dir);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["direct"] = dir;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.CHANGE_DIRECT, arg);
        }
        public void turnNo(sbyte no)
        {
            //Debug.Log("turnNo中 参数为" + no);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["no"] = no;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.TURN_NO, arg);
        }
        public void setShift(Vector2 shift)
        {
            Debug.Log("在setShift中参数为" + shift);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["shift"] = shift;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.DO_SHIFT, arg);
        }
        public void updateEnd()
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.UPDATE_END, arg);
        }
        public void int64(object arg)
        {
            Debug.Log(arg.GetType());
        }
    }
}