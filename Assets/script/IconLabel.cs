using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IconLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public abstract GameObject createPhantasm(sbyte index);
    public void onExit()
    {
        Debug.Log("IconLabel中"+gameObject+"onExitLable...........");
        if (mouseListener.main.dragObj != null && mouseListener.main.dragObj.tag == "headIcon")
        {
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
