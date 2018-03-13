using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headLable : MonoBehaviour {
    public sbyte roleNo;
    public void onClick()
    {
        mouseListener.main.dragObj = gameObject;
    }
    public void onUnClick()
    {
        if (mouseListener.main.dragObj == gameObject)
        {
            mouseListener.main.dragObj = null;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
