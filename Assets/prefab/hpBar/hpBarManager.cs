using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBarManager : MonoBehaviour {
    public static hpBarManager main;
    public GameObject hpBar;
	// Use this for initialization
	void Start () {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
	}
	public void CreateHpBar(GameObject owner,Color c)
    {
        GameObject newone = Instantiate(hpBar, transform);
        newone.GetComponent<hpBarControl>().followWith=owner;
        newone.GetComponent<Image>().color = c;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
