using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_misslieStand : Skill{
    protected sbyte prafebIndex;
    protected Vector2 relativeInitPos = Vector2.zero;//投射物初始位置
    protected float relativeZ = 0;//投射物初始转向
    protected List<Delegate.withNothing> onhit = new List<Delegate.withNothing>();
    protected bool destoryWhenHit = true;
    protected bool initFaceTraget=true;//投射物是否轉向初始對準目標
    // Use this for initialization
    public override void trigger(object traget)
    {
        Debug.Log("in misslie_stand prefabIndex is "+ prafebIndex);
        GameObject newone = Instantiate(EffectionTable.main.effections[prafebIndex],transform.position+(Vector3)relativeInitPos, EffectionTable.main.effections[prafebIndex].transform.rotation);
        float z = relativeZ;
        if (initFaceTraget)
        {
            z -= AngleGetter.GetAnglefromZero3D(((GameObject)traget).transform.position-transform.position);
        }
        newone.transform.eulerAngles = new Vector3(0, 0, z);
        missile missile = newone.GetComponent<missile>();
        missile.traget = (GameObject)traget;
        missile.onHitTraget = missile.destorySelf;
        foreach(Delegate.withNothing fuction in onhit)
        {
            missile.onHitTraget += fuction;
        }
        if (destoryWhenHit)
        {
            missile.onHitTraget += missile.destorySelf;
        }
    }
}
