﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_no1 : Skill {
    public override void trigger(GameObject traget)
    {
        Vector3 toward = traget.transform.position - transform.position;
        Vector3 tragetPos=transform.position+ 3*toward.normalized;
        GameObject newone= Instantiate(EffectionTable.main.effections[4],tragetPos, EffectionTable.main.effections[0].transform.rotation);
        newone.transform.eulerAngles = new Vector3(0,180, AngleGetter.GetAnglefromZero3D(toward) +90);
        // traget.GetComponent<Foot>().rush_Back(toward.normalized, 0.35f);
        traget.GetComponent<Foot>().shake(0.2f);
    }

    // Use this for initialization
    void Start () {
		
	}
}