using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBarManager : MonoBehaviour {
    public static hpBarManager main;
    public GameObject hpBar;
    public Dictionary<sbyte,hpbar> hpBarList=new Dictionary<sbyte, hpbar>();
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
	public void createHpBar(sbyte ownerId,GameObject owner,int maxhp,bool local)
    {
        GameObject newone = Instantiate(hpBar, transform);
        hpbar script = newone.GetComponent<hpbar>();
        script.setHpbar(owner,maxhp,local);
        hpBarList[ownerId] = script;
    }
    public void updateHpBar(sbyte ownerId,int updateNum)
    {
        hpBarList[ownerId].nowHp += updateNum;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
