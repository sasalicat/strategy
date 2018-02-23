using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livingBomb : effection {
    Vector3 oriLocalPos;
	// Use this for initialization
	void Start () {
        oriLocalPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = oriLocalPos;
        Vector2 shift = Random.insideUnitCircle * 0.25f;
        transform.position += (Vector3)shift;
    }
}
