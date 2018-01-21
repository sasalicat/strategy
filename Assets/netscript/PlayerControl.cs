using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            KBEngineApp.app.player().cellCall("move",new object[]{(sbyte)KeyCode.W});
        }
	}
}
