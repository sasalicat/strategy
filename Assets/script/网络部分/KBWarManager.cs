using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class KBWarManager : WarFieldManager
{
    public const sbyte ADD_UNIT = 0;
    public const sbyte TURN_NO = 1;
    public const sbyte CHANGE_MOVING = 2;
    public const sbyte CHANGE_DIRECT = 3;
    public const sbyte CHANGE_SPEED = 4;
    public const sbyte DO_SHIFT = 5;
    public const sbyte UPDATE_END = 6;
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
    public void addOrder(sbyte actionNo,Dictionary<string,object> args)
    {
        orders.Add(new Order(actionNo, args));
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
                switch (noworder.actionNo)
                {
                    case ADD_UNIT:
                        {
                            short rolekind = (short)noworder.args["kind"];
                            Vector2 pos = (Vector2)noworder.args["position"];
                            roles[(sbyte)noworder.args["no"]] = Instantiate(RoleList.main.roles[rolekind], new Vector3(pos.x, pos.y, 0), this.transform.rotation);
                            Debug.Log("role:" + roles[(sbyte)noworder.args["no"]]);
                            foots[(sbyte)noworder.args["no"]] = roles[(sbyte)noworder.args["no"]].GetComponent<Foot>();
                            break;
                        }
                    case TURN_NO:
                        {
                            turnOwnerNo = (sbyte)noworder.args["no"];
                            break;
                        }
                    case CHANGE_MOVING:
                        {
                            foots[turnOwnerNo].moving = (bool)noworder.args["moving"];
                            break;
                        }
                    case CHANGE_DIRECT:
                        {
                            foots[turnOwnerNo].direct = (Vector2)noworder.args["direct"];
                            Debug.Log("direct 单位向量是:" + ((Vector2)noworder.args["direct"]).normalized);
                            break;
                        }
                    case CHANGE_SPEED:
                        {
                            foots[turnOwnerNo].speed = (float)noworder.args["speed"];
                            break;
                        }
                    case DO_SHIFT:
                        {
                            Vector3 shift = (Vector2)noworder.args["shift"];
                            roles[turnOwnerNo].transform.position += (shift);
                            break;
                        }
                    case UPDATE_END:
                        {
                            foots[turnOwnerNo].keepMove(cycle);
                            nextUpdate = cycle;
                            break;
                        }
                }
                orders.RemoveAt(0);
            }
        }
	}
}
