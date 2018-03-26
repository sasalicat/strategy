using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_sample : Skill{
    protected int prafebIndex;
	// Use this for initialization
    public override void trigger(object traget)
    {
        GameObject newone = Instantiate(EffectionTable.main.effections[prafebIndex], transform.position, EffectionTable.main.effections[0].transform.rotation);
    }
}
