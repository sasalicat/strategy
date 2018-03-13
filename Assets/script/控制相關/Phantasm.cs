using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantasm : MonoBehaviour {
    public sbyte roleNo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 centerPos= girdManager.main.getRealCenter(mouseListener.translateMouse());
        print("在幻影中real center is " + centerPos);
        transform.position = centerPos;
    }
}
