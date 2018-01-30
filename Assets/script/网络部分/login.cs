using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using KBEngine;
using UnityEngine.UI;
using KBEngine;


public class login : MonoBehaviour {
    public GameObject model;
    public GameObject buttom;//確定按鈕
    public GameObject field;//口令輸入區
    public Text inf;
    public Text passward;
	// Use this for initialization
	void Start () {
        KBEngine.Event.registerOut("onConnectState",this, "onConnectState");
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
        //KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");

    }

    // Update is called once per frame
    void Update () {
	   
	}
    public void onClick()
    {
        try
        {
            KBEngine.Event.fireIn("login", inf.text, passward.text, System.Text.Encoding.UTF8.GetBytes("这游戏叫什么名字比较好？"));
        }
        catch (Exception e)
        {

        }
     }
    public void onConnectState(bool state)
    {
        if (state)
        {
            Debug.Log("连线成功");
        }
        else
        {
            Debug.Log("连线失败");
        }
        
    }
    public void onLoginFailed(UInt64 s)
    {
        Debug.Log("登入失败");
    }
    public void onLoginSuccessfully(UInt64 uuid,Int32 id,Account account)
    {
        Debug.Log("登入成功！ uuid is" + uuid + " id is" + id);
        buttom.SetActive(false);
        field.SetActive(false);
    }
    public void onEnterWorld(Entity e)
    {
        Debug.Log("来自onEnterWorld id:"+e.id);
        GameObject newone = (GameObject)Instantiate(model, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        EntityControl newcontrl = newone.AddComponent<EntityControl>();
        newcontrl.entity = e;
        Debug.Log("在 onEnterWorld中 entity is"+e);
        e.renderObj = newcontrl;
        Debug.Log("設置renderObj:"+e.renderObj);
    }
    public void onEnterSpace(Entity e)
    {
        Debug.Log("来自onEnterSpace id:"+e.id);
    }
    public void onLeaveWorld(Entity e)
    {
    }
}
