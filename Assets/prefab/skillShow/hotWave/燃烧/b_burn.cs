using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_burn : Buff {
    private GameObject eff;
    public override sbyte no
    {
        get
        {
            return 0;
        }
    }

    public override void onAdd()
    {
        eff=Instantiate(EffectionTable.main.effections[7],transform);
        eff.transform.localPosition = new Vector3(-0.25f, -4, 0);
        eff.transform.localScale = new Vector3(4.25f,3.4f,0);
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
