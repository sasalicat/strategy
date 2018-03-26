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
        private int count = 1;

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
            Debug.Log("加新的角色 no"+no+" kind"+kind);
            Dictionary<string, object> arg=new Dictionary<string, object>();
            arg["kind"] = kind;
            arg["skillList"] = skillList["list"];
            Debug.Log("in add unit skillList is" + ((List<object>)skillList["list"]).Count);
            arg["position"] = new Vector2(posx, posy);
            arg["no"] = no;
            ((KBWarManager)WarFieldManager.manager).addOrder( KBWarManager.ADD_UNIT, arg);
        }
        public void setMoving(sbyte mov)
        {
            //Debug.Log("setmoving中 参数为"+mov);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["moving"] = (mov==1);
            ((KBWarManager)WarFieldManager.manager).addOrder( KBWarManager.CHANGE_MOVING, arg);
        }
        public void setSpeed(float sp)
        {
            //Debug.Log("setSpeed中 参数为" + sp);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["speed"] = sp;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.CHANGE_SPEED, arg);
        }
        public void setDirect(Vector2 dir)
        {
           // Debug.Log("setDirect中 参数为" + dir);
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
            //Debug.Log("在setShift中参数为" + shift);
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["shift"] = shift;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.DO_SHIFT, arg);
        }
        public void updateEnd(Int32 count)
        {
           // Debug.Log("帧" + count + "结束---------------------------------------");
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["count"] = count;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.UPDATE_END, arg);
        }
        public void int64(object arg)
        {
            Debug.Log(arg.GetType());
        }
        public void takeDamage(sbyte num)
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["num"] = num;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.TAKE_DAMAGE, arg);
        }
        public void beTreat(sbyte num)
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["num"] = num;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.BEEN_HEAL, arg);
        }
        public void useSkill(sbyte skillIndex,sbyte tragetNo)
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["index"] = skillIndex;
            arg["tragetNo"] = tragetNo;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.USE_SKILL, arg);
        }
        public void useSkillmulti(sbyte skillIndex, Dictionary<string,object> tragets)//多目標技能
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["index"] = skillIndex;

            arg["tragets"] = tragets["list"];
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.USE_SKILL, arg);
        }
        public void beRepel(Vector2 arraw,float time)
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["arraw"] = arraw;
            arg["time"] = time;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.BE_REPEL, arg);
        }
        public void addBuff(sbyte buffNo)
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["no"] = buffNo; ;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.ADD_BUFF, arg);
        }
        public void delBuff(sbyte buffNo)
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["no"] = buffNo; ;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.DELETE_BUFF, arg);
        }
        public void died()
        {
            Debug.Log("receive died");
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.DIED, null);
        }
        public void setcanMove(sbyte mov)
        {
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["canMove"] = (mov == 1);
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.SET_CAN_MOVE, arg);
        }
        public void createEffection(short effectionNo,sbyte tragetNo)
        {
            //Debug.Log("Account 收到 createEffection 的呼叫");
            Dictionary<string, object> arg = new Dictionary<string, object>();
            arg["effectionNo"] = (int)effectionNo;
            arg["tragetNo"] = tragetNo;
            ((KBWarManager)WarFieldManager.manager).addOrder(KBWarManager.CREATE_EFFECTION_SP, arg);
        }
    }
}
