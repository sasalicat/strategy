using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IconLabel : MonoBehaviour {

	// Update is called once per frame
	protected void Update () {
        
	}
    public abstract GameObject createPhantasm(sbyte index);
    public void onExit()
    {
        Debug.Log("IconLabel中"+gameObject+"onExitLable...........");
        //Debug.Log("dragObj:" + mouseListener.main.dragObj + "tag:" + mouseListener.main.dragObj.tag);
        if (mouseListener.main.dragObj != null && mouseListener.main.dragObj.tag == "headIcon")
        {
            Debug.Log("在创建幻影之前 dragObj为" + mouseListener.main.dragObj);
            mouseListener.main.dragObj = createPhantasm(mouseListener.main.dragObj.GetComponent<headLable>().roleNo);
        }
    }
    public void beClick()
    {
        Debug.Log("mouse down#############");
        if (mouseListener.main.dragObj == null)
            mouseListener.main.dragObj = gameObject;
    }
    public void beUnClick()
    {
        mouseListener.main.dragObj = null;
    }
}
