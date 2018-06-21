using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadIconList : MonoBehaviour {
    public static HeadIconList main;
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
    public List<GameObject> roleHeadIcons;
    public List<GameObject> trapHeadIcons;
	// Update is called once per frame
	void Update () {
		
	}
}
