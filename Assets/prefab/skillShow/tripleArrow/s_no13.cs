using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_no13 : Skill {
    public override void trigger(object list)
    {
        foreach (GameObject traget in (List<GameObject>)list)
        {
            GameObject newone = Instantiate(EffectionTable.main.effections[14], transform.position, EffectionTable.main.effections[0].transform.rotation);
            missile missile = newone.GetComponent<missile>();
            missile.traget = traget;
            missile.onHitTraget = missile.destorySelf;
        }
    }

    // Use this for initialization
    void Start () {
		
	}

}
