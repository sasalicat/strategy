using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantasm : MonoBehaviour {
    public const sbyte ROLE = 0;
    public const sbyte TRAP = 1;
    public sbyte roleNo;
    public sbyte radiu = 2;
    public sbyte kind = ROLE;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (radiu == 2)
        {
            Vector2 centerPos = girdManager.main.getRealCenter(mouseListener.translateMouse());
            print("在幻影中real center is " + centerPos);
            transform.position = centerPos;
        }
        else if (radiu == 1)
        {
            Vector2 centerPos = girdManager.main.getRealCenter(mouseListener.translateMouse());
            print("在幻影中real center is " + centerPos);
            transform.position = centerPos;
        }
    }
}
