using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBarControl : MonoBehaviour {
    public GameObject followWith=null;
    public readonly Vector2 offset = new Vector2(0,3);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (followWith != null)
        {
            transform.position = (Vector2)followWith.transform.position + offset;
        }
	}
}
