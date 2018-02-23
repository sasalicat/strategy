using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Foot : MonoBehaviour {
    public bool moving = false;
    public bool debug = false;
    public Vector2 dir = new Vector2(0, 0);
    //rush------------------------------
    private float rushTime = 0;
    private float hasRushTime = 0;
    private Vector3 rushSpeed=Vector3.zero;
    private Vector3 lastRush = Vector3.zero;
    //shake-----------------------------
    private float shakeTime = 0;
    private Vector2 lastShakeShift = Vector2.zero;
    private float _shakeWeight = 0.5f;//晃动的权重,数值越大摇晃的距离越远
    //repel------------------------------
    public Vector2 repelSpeed = Vector2.zero;
    public float repelTime = 0;

    public float shakeWeight
    {
        set
        {
            _shakeWeight = value;
        }
    }
    public Vector2 direct
    {
        set
        {
            dir = value.normalized;
        }
    }
    public float speed = 2;
    private float timeleft;
	// Use this for initialization
	void Start () {
		
	}
    //真实移动-------------------------------------------------------------------------
	public void keepMove(float time)//平滑移动
    {
        timeleft = time;
    }
    public void tp(float time)//立即传送
    {
        if (moving)
        {
            transform.position += ((Vector3)dir) * time*speed;
            if (debug)
            {
                Debug.Log("after move pos is(" + transform.position.x + "," + transform.position.y + "," + transform.position.z + ")");
            }
        }
        //repel的操作
        if (repelTime > 0.0001f)
        {
            transform.position += (Vector3)repelSpeed * time;
            Debug.Log("在repel中time为" + time);
            repelTime -= time;
        }
    }
    public void repelBegin(Vector2 arraw,float time)
    {
        this.repelSpeed = arraw / time;
        this.repelTime = time;
    }
    //特效移动--------------------------------------------------------------------------
    public void rush_Back(Vector3 shift,float time)
    {
        if (rushTime > 0)//已经有一个rush进程
        {
            Vector3 distant = rushSpeed * hasRushTime;
            Debug.Log("rush back 中已经rush了" + distant);
            transform.position -= distant;//还原冲刺距离
        }
        rushSpeed = shift / time;
        rushTime = time;
        hasRushTime = 0;
        lastRush = shift;
    }
    public void shake(float time)
    {
        shakeTime += time;
    }
	// Update is called once per frame
	void Update () {
        /*
                    timeleft -= Time.deltaTime;
                    if (moving && timeleft >= 0)
                    {


                        Vector3 normalDir = ((Vector3)dir).normalized;
                        transform.position += (normalDir) * speed * Time.deltaTime;
                        if (debug)
                        {
                            Debug.Log("enter moving dir is" + normalDir + "speed is" + speed);
                        }
                        //Debug.Log("normal:"+ normalDir+"速度:(" +normalDir.x * speed * 0.1f+","+ normalDir.y * speed * 0.1f);

                }*/
        if (rushTime > 0)
        {
            transform.position += rushSpeed * Time.deltaTime;
            rushTime -= Time.deltaTime;
            hasRushTime += Time.deltaTime;
            if (rushTime<=0)
            {
                transform.position -= hasRushTime* rushSpeed;
            }
        }
        if (shakeTime > 0)//无视4位后的精度
        {
            transform.position -= (Vector3)lastShakeShift;

            shakeTime -= Time.deltaTime;
            if (shakeTime > 0)
            {
                Vector2 shift = Random.insideUnitCircle* _shakeWeight;
                lastShakeShift = shift;
                transform.position += (Vector3)shift;
            }
            else
            {
                lastShakeShift = Vector2.zero;//清空上次的摇摆值
            }
        }
	}
}
