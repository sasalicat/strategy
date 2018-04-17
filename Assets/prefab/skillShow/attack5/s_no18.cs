﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_no18 : Skill
{
    public override void trigger(object traget)
    {
        GetComponent<Foot>().swing(60, 0.15f, 2);
        Vector3 toward = ((GameObject)traget).transform.position - transform.position;
        Vector3 tragetPos = transform.position + 3 * toward.normalized;
        GameObject newone = Instantiate(EffectionTable.main.effections[16], tragetPos, EffectionTable.main.effections[16].transform.rotation);
        newone.transform.eulerAngles = new Vector3(0, 180, AngleGetter.GetAnglefromZero3D(toward) + 90);
        // traget.GetComponent<Foot>().rush_Back(toward.normalized, 0.35f);
        
        ((GameObject)traget).GetComponent<Foot>().rush_Back(toward, 0.2f);

    }

    // Use this for initialization
    void Start()
    {

    }
}