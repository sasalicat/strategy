using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seizeSeat : Trap {
    private long ownerId;
    public override void onInit(long ownerId)
    {
        girdManager.main.aftRoleIn(gameObject);
        this.ownerId = ownerId;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
