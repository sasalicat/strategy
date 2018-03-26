using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectionTable : MonoBehaviour {
    public static EffectionTable main;
    protected void Start()
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
    public List<GameObject> effections = new List<GameObject>();
    public List<GameObject> sp_effections = new List<GameObject>();
	// Update is called once per frame
	void Update () {
		
	}
}
