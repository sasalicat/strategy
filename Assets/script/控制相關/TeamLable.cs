using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeamLable : IconLabel {
    public GameObject itemLabel;
    private Int32 nowTurnId;
    private bool hasDele=false;
    // Use this for initialization
    void Start () {
        mouseListener.main.onReleaseDrag += delPhantasm;
        if (!hasDele)
        {
            WarFieldManager.manager.AfterCreateRole += aftCreateRole;
            WarFieldManager.manager.RoundBegin += onRound;
            hasDele = true;
        }
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
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
                    WarFieldManager.manager.createRole(script.roleNo, gobj.transform.position);
            }
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
