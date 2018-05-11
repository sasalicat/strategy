using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temporaryShield : Buff{
    private GameObject eff;
    public override sbyte no
    {
        get
        {
            return 3;
        }
    }

    public override void onAdd()
    {
        eff = Instantiate(EffectionTable.main.effections[18],gameObject.transform.position,gameObject.transform.rotation,transform);
        eff.GetComponent<tempShieldEff>().master = gameObject;
    }

    public override void onDelete()
    {
        Destroy(eff);
    }

    public override void onUpdate(float time)
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
