using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleList : MonoBehaviour {
    public static RoleList main;
    public List<GameObject> roles;
	// Use this for initialization
	protected void Start () {
		if(main !=null && main != this)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
