using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionCard : MonoBehaviour {
    public const int TO_ROLE = 0;
    public const int TO_TRAP = 1;
    public const int TO_ALL = 2;
    public const int TO_NONE = 3;
    public abstract void action(GameObject traget);
    public int tragetKind = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
