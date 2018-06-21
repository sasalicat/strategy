using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLabel : IconLabel {
    public GameObject TeamLabel;
    private bool hasDele = false;
    private Int32 nowTurnId;
    private int actionNum = 2;
    public void delPhantasm_t(GameObject gobj)
    {
        Debug.Log("delPhantasm 被觸發");
        ActionPhant actionP = GetComponent<ActionPhant>();
        if (actionP!=null)
        {
            Destroy(gobj);
            return;
        }
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
       // mouseListener.main.onReleaseDrag += delPhantasm_t;
        if (!hasDele)
             {
                    WarFieldManager.manager.AfterCreateTrap += aftCreateTrap;
                    WarFieldManager.manager.RoundBegin += onRound;
                    WarFieldManager.manager.AfterUseCard += aftUseCard;
                     hasDele = true;
            }
        gameObject.SetActive(false);
        actionNum = 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void aftCreateTrap(GameObject trap)
    {
        actionNum -= 1;
        if (actionNum <= 0)
        {
            if (nowTurnId != ((KBWarManager)WarFieldManager.manager).localId)
                gameObject.SetActive(false);
        }
    }
    public void onRound(Int32 ownerId)
    {
        Debug.Log("在itemLabel 中ownerId为"+ownerId+"localid 为"+ ((KBWarManager)KBWarManager.manager).localId);
        //nowTurnId = ownerId;
        //if (((KBWarManager)KBWarManager.manager).localId!= nowTurnId)
        //{
            gameObject.SetActive(false);
        //}
    }
    public void aftUseCard(int no)
    {
        actionNum -= 1;
        if (actionNum <= 0)
        {
            if (nowTurnId != ((KBWarManager)WarFieldManager.manager).localId)
                gameObject.SetActive(false);
        }
    }
    public override GameObject createPhantasm(sbyte rno)
    {
        ActionCard card = mouseListener.main.dragObj.GetComponent<ActionCard>();
        if (card!=null)
        {
            Debug.Log("進入card不等於null");
            GameObject phant = Instantiate(ActionList.main.list[rno]);
            ActionPhant script = phant.AddComponent<ActionPhant>();
            script.actionNo = rno;
            script.card = card;
            script.traget_kind = card.tragetKind;
            return phant;
        }
        else
        {
            GameObject phant = Instantiate(TrapList.main.traps[rno]);

            Phantasm script = phant.AddComponent<Phantasm>();
            script.roleNo = rno;
            script.kind = Phantasm.TRAP;
            Debug.Log("在创造陷阱中 rno为" + rno + " big为" + TrapList.main.traps[rno]);
            if (!TrapList.main.bigMarker[rno])
            {
                Debug.Log("设置了半径");
                script.radiu = 1;
                girdManager.main.radiu = 1;
            }
            else
            {
                girdManager.main.radiu = 2;
            }
            return phant;
        }
    }
}

