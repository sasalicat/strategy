using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coma : Buff {
    private GameObject obj;
    public override sbyte no
    {
        get
        {
            return 2;
        }
    }

    public override void onAdd()
    {
        obj= Instantiate(EffectionTable.main.effections[12], transform);
        obj.transform.localPosition = new Vector3(0, 3.5f, 0);
    }

    public override void onDelete()
    {
        Destroy(obj);
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
