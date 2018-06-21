using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour {
    public static ActionList main;
    public List<GameObject> list=new List<GameObject>();
    void Start()
    {
        if (main != null && main != this)
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
