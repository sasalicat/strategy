using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillNameList : MonoBehaviour {
    public static skillNameList main;
    public List<string> skillNames;
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
}
