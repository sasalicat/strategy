using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetSurgery : ActionCard
{
    List<IntPair> offset = null;
    List<GameObject> area = new List<GameObject>();
    GameObject traget;
    public Color valify(girdGroup group,GameObject gird,IntPair indexs)
    {
        if (group.valid(gird.transform.position,traget))
        {
            return girdManager.main.color_establish;
        }
        else
        {
            return girdManager.main.color_error;
        }
    }
    public void onGirdClick(gridItem grid)
    {
        sbyte rno= traget.GetComponent<SkillBag>().roleNo;
        sbyte sno = 0;
        Dictionary<string, object> args=new Dictionary<string, object>();
        args["roleNo"] = rno;
        args["position"] = girdManager.main.getRealCenter(grid.transform.position);
        WarFieldManager.manager.useActionCard(sno,args);
        foreach (GameObject gird in area)
        {
            gird.GetComponent<gridItem>().onGirdClick -= this.onGirdClick;
        }
        girdManager.main.reSetColorList(area);
    }
    public override void action(GameObject traget)
    {
        Debug.Log("在傀儡術中 traget:"+traget);
        Vector2 pos = traget.transform.position;
        Debug.Log("tragetIndex 為" + girdManager.main.getIndexs(pos));
        List<IntPair> map=new List<IntPair>();
        IntPair oriIndexs = girdManager.main.getIndexs(pos);
        foreach(IntPair o in offset)
        {
            map.Add(oriIndexs+o);
        }
        this.traget = traget;
        area= girdManager.main.turnGreenByIndexs(map,valify);
        foreach(GameObject gird in area)
        {
            gird.GetComponent<gridItem>().onGirdClick += this.onGirdClick;
        }
    }
    public void onClick(Vector2 pos)
    {
        IntPair pair= girdManager.main.getIndexs(pos);
    }


    // Use this for initialization
    void Start () {
		tragetKind=0;
        /*offset = new List<IntPair>();
        offset.Add(new IntPair(-1, -1));
        offset.Add(new IntPair(-2, -1));
        offset.Add(new IntPair(-3, -1));
        offset.Add(new IntPair(-3, 0));
        offset.Add(new IntPair(-2, 0));
        offset.Add(new IntPair(-1, 0));
        offset.Add(new IntPair(-1, 1));
        offset.Add(new IntPair(-1, 2));
        offset.Add(new IntPair(0, 2));
        offset.Add(new IntPair(0, 1));
        offset.Add(new IntPair(0, 0));
        offset.Add(new IntPair(1, 0));
        offset.Add(new IntPair(2, 0));
        offset.Add(new IntPair(2, -1));
        offset.Add(new IntPair(1, -1));
        offset.Add(new IntPair(0, -1));
        offset.Add(new IntPair(0,-2));
        offset.Add(new IntPair(0, -3));
        offset.Add(new IntPair(-1, -3));
        offset.Add(new IntPair(-1, -2));*/
        offset = new List<IntPair>();
        offset.Add(new IntPair(0, 0));
        offset.Add(new IntPair(1, 0));
        offset.Add(new IntPair(2, 0));
        offset.Add(new IntPair(-1, 0));
        offset.Add(new IntPair(-2, 0));
        offset.Add(new IntPair(0, -1));
        offset.Add(new IntPair(0, -2));
        offset.Add(new IntPair(0, 1));
        offset.Add(new IntPair(0, 2));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
