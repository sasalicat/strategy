using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapList : MonoBehaviour {
    public static TrapList main;
    public List<GameObject> traps;
    public List<bool> bigMarker;
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
    void Update()
    {

    }

}
