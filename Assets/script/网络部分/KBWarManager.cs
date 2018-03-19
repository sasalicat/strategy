using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using System;

public class KBWarManager : WarFieldManager
{
    public const sbyte ADD_UNIT = 0;
    public const sbyte TURN_NO = 1;
    public const sbyte CHANGE_MOVING = 2;
    public const sbyte CHANGE_DIRECT = 3;
    public const sbyte CHANGE_SPEED = 4;
    public const sbyte DO_SHIFT = 5;
    public const sbyte UPDATE_END = 6;
    public const sbyte TAKE_DAMAGE = 7;
    public const sbyte USE_SKILL = 8;
    public const sbyte BEEN_HEAL = 9;
    public const sbyte BE_REPEL = 10;
    public const sbyte ADD_BUFF = 11;
    public const sbyte DELETE_BUFF = 12;
    public const sbyte DIED = 13;
    public const sbyte SET_CAN_MOVE = 14;
    private class Order
    {
        public sbyte actionNo;
        public Dictionary<string, object> args; 
        public Order(sbyte actionNo,Dictionary<string,object> args)
        {
            this.actionNo = actionNo;
            this.args = args;
        }
    }
    private List<Order> orders=new List<Order>();
    private sbyte turnOwnerNo;
    private float nextUpdate = 0;
    private float cycle = 0.1f;
    private Dictionary<sbyte, Foot> foots=new Dictionary<sbyte, Foot>();
    private Dictionary<sbyte, SkillBag> sbags = new Dictionary<sbyte, SkillBag>();
    public Dictionary<sbyte, Vector2> debugPos = new Dictionary<sbyte, Vector2>();
    public void addOrder(sbyte actionNo,Dictionary<string,object> args)
    {
        orders.Add(new Order(actionNo, args));
    }
    public void removeRole(GameObject role)
    {
        foreach(KeyValuePair<sbyte,GameObject> pair in roles)
        {
            if (pair.Value == role)
            {
                Debug.Log("在removeRole中");
                roles.Remove(pair.Key);
                break;
            }
        }
    }
    // Use this for initialization
    protected void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        nextUpdate -= Time.deltaTime;
        if (nextUpdate < 0)
        {
            while (orders.Count > 0)
            {
                Order noworder = orders[0];
                if (noworder == null)
                {
                    Debug.Log("即将发生空值错误,这是最后的报错祝,你好运未来的我,印出整个orders列表:");
                    for(int i = 0; i < orders.Count; i++)
                    {
                        Debug.Log("index" + i + " order:" + orders[i] + " actionNo:"+orders[i].actionNo);
                    }
                }
                //Debug.Log(orders.Count + "orders are waiting");
                switch (noworder.actionNo)
                {
                    case ADD_UNIT:
                        {
                            short rolekind = (short)noworder.args["kind"];
                            Vector2 pos = (Vector2)noworder.args["position"];
                            //Debug.Log(RoleList.main);

                            roles[(sbyte)noworder.args["no"]] = Instantiate(((RoleList)RoleList.main).roles[rolekind], new Vector3(pos.x, pos.y, 0), this.transform.rotation);
                            debugPos[(sbyte)noworder.args["no"]] = pos;
                            Debug.Log("在addunit中 初始pos:("+pos.x+","+pos.y+")");
                            //Debug.Log("role:" + roles[(sbyte)noworder.args["no"]]);
                            foots[(sbyte)noworder.args["no"]] = roles[(sbyte)noworder.args["no"]].AddComponent<Foot>();
                            if ((sbyte)noworder.args["no"] == 1)
                            {
                                foots[(sbyte)noworder.args["no"]].debug = true;
                            }
                            SkillBag bag= roles[(sbyte)noworder.args["no"]].AddComponent<SkillBag>();
                            sbags[(sbyte)noworder.args["no"]] = bag;
                            List<object> list = (List<object>)noworder.args["skillList"];
                            //Debug.Log(rolekind+"no"+ (sbyte)noworder.args["no"] + "在add_unit中:");
                            //foreach (object obj in list) {
                              //  Debug.Log(obj);
                            //}
                            bag.init(((List<object>) noworder.args["skillList"]));
                            roles[(sbyte)noworder.args["no"]].AddComponent<BuffBag>();
                            Skin skin= roles[(sbyte)noworder.args["no"]].AddComponent<Skin>();
                            skin.onDestory += removeRole;
                            //设置格子主管的占用
                            AfterCreateRole(roles[(sbyte)noworder.args["no"]]);
                            break;
                        }
                    case TURN_NO:
                        {
                            turnOwnerNo = (sbyte)noworder.args["no"];
                            Debug.Log("turn no:" + turnOwnerNo);
                            break;
                        }
                    case CHANGE_MOVING:
                        {
                            foots[turnOwnerNo].moving = (bool)noworder.args["moving"];
                            Debug.Log("change moving:" + foots[turnOwnerNo].moving);
                            break;
                        }
                    case CHANGE_DIRECT:
                        {
                            foots[turnOwnerNo].direct = (Vector2)noworder.args["direct"];
                            Debug.Log("set direct:" + ((Vector2)noworder.args["direct"]));
                            break;
                        }
                    case CHANGE_SPEED:
                        {
                            foots[turnOwnerNo].speed = (float)noworder.args["speed"];
                            Debug.Log("change speed:" + (float)noworder.args["speed"]);
                            break;
                        }
                    case DO_SHIFT:
                        {

                            Vector3 shift = (Vector2)noworder.args["shift"];
                            roles[turnOwnerNo].transform.position += (shift);
                            debugPos[turnOwnerNo] += (Vector2)noworder.args["shift"];
                            Debug.Log("set shift:(" + shift.x + "," + shift.y + ")");
                            break;
                        }
                    case UPDATE_END:
                        {
                            foreach(sbyte i in roles.Keys)
                            {

                                 Foot foot = roles[i].GetComponent<Foot>();

                                if (foot.moving)
                                {
                                    debugPos[i] += foot.dir * cycle * foot.speed;
                                    Debug.Log("dir add:" + foot.dir * cycle * foot.speed);
                                }
                                if (foot.repelTime > 0.0001f)
                                {
                                    debugPos[i] += foot.repelSpeed * cycle;
                                    Debug.Log("time"+foot.repelTime+" repel add:" + foot.repelSpeed * cycle);
                                }
                                BuffBag buffBag = roles[i].GetComponent<BuffBag>();
                                foreach(KeyValuePair<sbyte,Buff> pair in buffBag.buffsWithIn)
                                {
                                    pair.Value.onUpdate(cycle);
                                }
                                Debug.Log("no" + i + " position is("+debugPos[i].x+","+debugPos[i].y+")");
                            }
                            foreach (KeyValuePair<sbyte,GameObject> pair in roles){
                                //pair.Value.GetComponent<Foot>().keepMove(cycle);
     
                                pair.Value.GetComponent<Foot>().tp(cycle);
                            } 
                            nextUpdate = cycle;
                            Debug.Log("帧 " + (Int32)noworder.args["count"] + "结束-----------------------------");
                            break;
                        }
                    case TAKE_DAMAGE:
                        {
                            Debug.Log("takeDamage" + (sbyte)noworder.args["num"]);
                            FloatingCreate.main.createAt((sbyte)noworder.args["num"], roles[turnOwnerNo].transform.position);
                            break;
                        }
                    case USE_SKILL:
                        {
                            Debug.Log("index is "+ (sbyte)noworder.args["index"]+"traget no is "+ (sbyte)noworder.args["tragetNo"]);
                            sbags[turnOwnerNo].skillsInside[(sbyte)noworder.args["index"]].trigger(roles[(sbyte)noworder.args["tragetNo"]]);
                            break;
                        }
                    case BEEN_HEAL:
                        {
                            FloatingCreate.main.createAt((sbyte)noworder.args["num"], roles[turnOwnerNo].transform.position,FloatingCreate.GREEN_BEGIN);
                            break;
                        }
                    case BE_REPEL:
                        {
                            Debug.Log("berepel");
                            roles[turnOwnerNo].GetComponent<Foot>().repelBegin((Vector2)noworder.args["arraw"],(float)noworder.args["time"]);
                            break;
                        }
                    case ADD_BUFF:
                        {
                            Debug.Log("add buff no" + (sbyte)noworder.args["no"]);
                            BuffBag bag = roles[turnOwnerNo].GetComponent<BuffBag>();
                            string bname = BuffList.main.buffs[(sbyte)noworder.args["no"]];
                            Buff newbuff = (Buff)roles[turnOwnerNo].AddComponent(System.Type.GetType(bname));
                            bag.buffsWithIn[(sbyte)noworder.args["no"]] = newbuff;
                            newbuff.onAdd();
                            break;
                        }
                    case DELETE_BUFF:
                        {
                            Debug.Log("delete buff no" + (sbyte)noworder.args["no"]);
                            BuffBag bag = roles[turnOwnerNo].GetComponent<BuffBag>();
                            bag.buffsWithIn[(sbyte)noworder.args["no"]].onDelete();
                            if (! bag.buffsWithIn.Remove((sbyte)noworder.args["no"]))//如果要remove的key不在里面
                            {//报错
                                Debug.LogError("在deletebuff中 buff no"+ (sbyte)noworder.args["no"]+"不在buffbag内");
                            }
                            break;
                        }
                    case DIED:
                        {
                            Debug.Log("died is coming");
                            roles[turnOwnerNo].GetComponent<Skin>().diedEffect();
                            break;
                        }
                    case SET_CAN_MOVE:
                        {
                            foots[turnOwnerNo].canMove = (bool)noworder.args["canMove"];
                            break;
                        }
                }
                orders.Remove(noworder);
                if (nextUpdate >= 0)//从updateend中跳出
                {
                    break;//终止update
                }
            }
        }
	}
    public override void createRole(sbyte rno,Vector2 pos)
    {
        KBEngine.KBEngineApp.app.player().cellCall("createRole", new object[] { rno, pos });
    }
    public void debugGameStart()
    {
        KBEngine.KBEngineApp.app.player().cellCall("debugGame", new object[] {});
    }
}
