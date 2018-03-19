using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_no5 : Skill
{
    public override void trigger(GameObject traget)
    {
        GameObject newone = Instantiate(EffectionTable.main.effections[5], transform.position, EffectionTable.main.effections[0].transform.rotation);
        missile missile = newone.GetComponent<missile>();
        missile.traget = traget;
        missile.onHitTraget = missile.destorySelf;
        // traget.GetComponent<Foot>().rush_Back(toward.normalized, 0.35f);
        
    }

    // Use this for initialization
    void Start()
    {

    }
}