using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffList : MonoBehaviour {
    public static BuffList main;
    public List<string> buffs;
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
    // Update is called once per frame
    void Update () {
		
	}
}
