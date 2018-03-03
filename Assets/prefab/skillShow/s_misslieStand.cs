using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_misslieStand : Skill{
    protected sbyte prafebIndex;
    protected Vector2 InitPos = Vector2.zero;//投射物初始位置
    protected float rotateZ = 0;//投射物初始转向
    protected List<missile.SimpleDele> onhit = new List<missile.SimpleDele>();
    // Use this for initialization
    public override void trigger(GameObject traget)
    {
        GameObject newone = Instantiate(EffectionTable.main.effections[prafebIndex],InitPos, EffectionTable.main.effections[prafebIndex].transform.rotation);
        newone.transform.eulerAngles = new Vector3(0, 0, rotateZ);
        missile missile = newone.GetComponent<missile>();
        missile.traget = traget;
        missile.onHitTraget = missile.destorySelf;
        foreach(missile.SimpleDele fuction in onhit)
        {
            missile.onHitTraget += fuction;
        }
    }
}
