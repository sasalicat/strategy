using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_no11 : Skill {
    public override void trigger(object traget)
    {
        GetComponent<Foot>().swing(60, 0.15f, 2);
        Vector3 toward = ((GameObject)traget).transform.position - transform.position;
        Vector3 tragetPos = transform.position;
        GameObject newone = Instantiate(EffectionTable.main.effections[15], tragetPos, EffectionTable.main.effections[15].transform.rotation);
        newone.transform.eulerAngles = new Vector3(0, 180, AngleGetter.GetAnglefromZero3D(toward) + 90);
        // traget.GetComponent<Foot>().rush_Back(toward.normalized, 0.35f);
        ((GameObject)traget).GetComponent<Foot>().shake(0.2f);
        //newone.GetComponent<effection>().destorySelf();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
