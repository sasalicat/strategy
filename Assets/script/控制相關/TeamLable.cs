using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        mouseListener.main.onReleaseDrag += delPhantasm;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onExit()
    {
        Debug.Log("onExitLable...........");
        if (mouseListener.main.dragObj!=null && mouseListener.main.dragObj.tag == "headIcon")
        {
            mouseListener.main.dragObj= createPhantasm(mouseListener.main.dragObj.GetComponent<headLable>().roleNo);
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
    public GameObject createPhantasm(sbyte roleNo)//創建一個自動找到正確位置的角色物件的幻象
    {
        GameObject phant= Instantiate(RoleList.main.roles[roleNo]);
        phant.AddComponent<Phantasm>().roleNo=roleNo;
        return phant;
    }
    public void delPhantasm(GameObject gobj)
    {
        Debug.Log("delPhantasm 被觸發");
        if (gobj.GetComponent<Phantasm>() != null)//確定是幻影
        {
            Destroy(gobj);
        }
    }
}
