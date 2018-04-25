using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLabel : IconLabel {
    public GameObject TeamLabel;
    private bool hasDele = false;
    private Int32 nowTurnId;
    public void delPhantasm_t(GameObject gobj)
    {
        Debug.Log("delPhantasm 被觸發");
        Phantasm script = gobj.GetComponent<Phantasm>();
        if (script != null && script.kind == Phantasm.TRAP)//確定是幻影
        {
            if (girdManager.main.Vaild(gobj.transform.position))
            {
                    WarFieldManager.manager.createTrap(script.roleNo, gobj.transform.position);
            }
            Debug.Log("删除幻影-陷阱");
            Destroy(gobj);
        }
    }
        // Use this for initialization
    void Start () {
        mouseListener.main.onReleaseDrag += delPhantasm_t;
        if (!hasDele)
                {
                    WarFieldManager.manager.AfterCreateTrap += aftCreateTrap;
                    WarFieldManager.manager.RoundBegin += onRound;
            hasDele = true;
        }
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void aftCreateTrap(GameObject trap)
    {
        if(nowTurnId!= ((KBWarManager)WarFieldManager.manager).localId)
            gameObject.SetActive(false);
    }
    public void onRound(Int32 ownerId)
    {
        Debug.Log("在itemLabel 中ownerId为"+ownerId+"localid 为"+ ((KBWarManager)KBWarManager.manager).localId);
        nowTurnId = ownerId;
        if (((KBWarManager)KBWarManager.manager).localId!= nowTurnId)
        {
            gameObject.SetActive(false);
        }
    }

    public override GameObject createPhantasm(sbyte index)
    {
        GameObject phant = Instantiate(TrapList.main.traps[index]);
        Phantasm script = phant.AddComponent<Phantasm>();
        script.roleNo = index;
        script.kind = Phantasm.TRAP;
        return phant;
    }
}

