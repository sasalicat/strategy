using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeamLable : IconLabel {
    public GameObject itemLabel;
    private Int32 nowTurnId;
    private bool hasDele=false;
    public List<short> listForCreate = null;
    public GameObject lastDragObj = null;
    List<GameObject> IconList = new List<GameObject>();
    public void onGetRoleNos(List<object> list)
    {
        List<short> newlist = new List<short>();
        foreach(object no in list)
        {
            Debug.Log("type is " + no.GetType());
            newlist.Add((short)no);
        }
        listForCreate = newlist;
    }
    // Use this for initialization
    void Start () {
        //mouseListener.main.onReleaseDrag += delPhantasm;
        WarFieldManager.manager.onGetRoleList += onGetRoleNos;
        if (!hasDele)
        {
            WarFieldManager.manager.AfterCreateRole += aftCreateRole;
            WarFieldManager.manager.RoundBegin += onRound;
            hasDele = true;
        }
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	protected void Update () {
        if (listForCreate != null)
        {
            foreach(GameObject icon in IconList)//删除所有现有的Icon
            {
                Destroy(icon);
            }
            foreach(sbyte no in listForCreate)//根据list创造新的icon
            {
                GameObject newIcon = Instantiate(HeadIconList.main.roleHeadIcons[no], gameObject.transform);
                newIcon.transform.localScale = new Vector3(1, 1, 1);
                IconList.Add(newIcon);
            }
            listForCreate = null;
        }
	}
    public void aftCreateRole(GameObject role)
    {
        Debug.Log("呼叫after createRole");
        if (nowTurnId == ((KBWarManager)WarFieldManager.manager).localId)
        {
            gameObject.SetActive(false);
            itemLabel.SetActive(true);
        }
    }

    public override GameObject createPhantasm(sbyte roleNo)//創建一個自動找到正確位置的角色物件的幻象
    {
        GameObject phant= Instantiate(RoleList.main.roles[roleNo]);
        phant.AddComponent<Phantasm>().roleNo=roleNo;
        lastDragObj = mouseListener.main.dragObj;
        girdManager.main.radiu = 2;
        Debug.Log("在创建幻影中 lastDragObj为"+lastDragObj);
        return phant;
    }
    public void delPhantasm(GameObject gobj)
    {
        Debug.Log("delPhantasm 被觸發");
        Phantasm script = gobj.GetComponent<Phantasm>();
        if (script != null && script.kind == Phantasm.ROLE)//確定是幻影
        {
            if (girdManager.main.Vaild(gobj.transform.position))
            {
                    //WarFieldManager.manager.createRole(script.roleNo, gobj.transform.position);
                    Debug.Log("创建角色中 lastDragObj为"+lastDragObj);
                    Destroy(lastDragObj);
            }
            lastDragObj = null;
            Debug.Log("删除幻影");
            Destroy(gobj);
        }
    }
    public void onGameStart()
    {
        girdManager.main.clearGirds();
        gameObject.SetActive(false);
    }
    public void onRound(Int32 ownerId)
    {
        Debug.Log("在teamLabel 中ownerId为" + ownerId + "localid 为" + ((KBWarManager)KBWarManager.manager).localId);
        nowTurnId = ownerId;
        if (((KBWarManager)KBWarManager.manager).localId == ownerId)
        {
            gameObject.SetActive(true);
        }
    }
}
