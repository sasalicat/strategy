using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class changeTeamButtom : MonoBehaviour {
    public bool teamRed = true;
	// Use this for initialization
	void Start () {
		
	}
	public void onClick()
    {
        if (teamRed)
        {
            GetComponent<Image>().color = Color.blue;
            teamRed = false;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            teamRed = true;
        }
    }

}
