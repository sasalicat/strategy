using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempShieldEff : effection {
    public GameObject master;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = master.transform.position;
	}
}
