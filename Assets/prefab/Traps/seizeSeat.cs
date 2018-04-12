using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seizeSeat : Trap {
    public override void onInit(int ownerId)
    {
        girdManager.main.aftRoleIn(gameObject);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
