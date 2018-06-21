using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridItem : MonoBehaviour {
    public delegate void withGirdItem(gridItem self);
    IntPair indexs = new IntPair(-1,-1);
    girdGroup group = null;
    public withGirdItem onGirdClick;
    public withGirdItem onEnterGrid;
    public withGirdItem onLeaveGrid;
    public void init(int x,int y, girdGroup group)
    {
        //Debug.Log("in init " + x + "," + y + "group:" + group);
        indexs = new IntPair(x, y);
        this.group = group;
    }
    public void onClick()
    {
        Debug.Log("gird"+indexs+"被點擊");
        onGirdClick(this);
    }
    /*public void onClick()
    {
        //Debug.Log("on click 被呼叫"+group);
        group.onclick((int)indexs.x,(int)indexs.y);
    }*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
