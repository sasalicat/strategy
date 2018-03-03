using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_no8 : s_misslieStand {
    void Start()
    {
        prafebIndex = 10;
    }
    public override void trigger(GameObject traget)
    {

        Vector3 arraw = traget.transform.position - transform.position;
        InitPos = transform.position;
        base.trigger(traget);
    }

}
