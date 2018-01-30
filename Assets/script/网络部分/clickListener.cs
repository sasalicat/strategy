using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class clickListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("screen:"+Input.mousePosition);
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = 32.5f;
            Vector3 pos=Camera.main.ScreenToWorldPoint(mousepos);
            Debug.Log(pos);
            if(KBEngineApp.app.player()!=null)
                KBEngineApp.app.player().cellCall("move",new Vector2(pos.x,pos.y));
        }
	}
}
