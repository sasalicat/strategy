using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_burnCounter : Buff {
    private bool hastwo = false;
    private bool hasone = false;
    private float counter = 3;
    private GameObject prab = null;
    Animator anim;
    public Sprite[] icons;
    private readonly Vector3 counterLocalPos = new Vector3(0, 4.5f, 0);
    public override sbyte no
    {
        get
        {
            return 1;
        }
    }

    public override void onAdd()
    {
        prab = Instantiate(EffectionTable.main.effections[8],transform);
        prab.transform.localPosition = counterLocalPos;
        anim = prab.GetComponent<Animator>();
    }

    public override void onDelete()
    {
        Debug.Log("活体炸弹的delete");
        Destroy(prab);
        GameObject obj = EffectionTable.main.effections[9];
        Instantiate(obj, transform.position, transform.rotation);
    }

    public override void onUpdate(float time)
    {
        counter -= time;
        if(counter<=2 && !hastwo)
        {
            anim.SetBool("twoh", true);
            hastwo = true;
        }
        else if(counter<=1 && !hasone)
        {
            anim.SetBool("oneh", true);
            hasone = true;//这么做是为了防止每一帧设置一次bool
        }
        //颤抖代码
        prab.transform.localPosition = counterLocalPos;
        Vector2 shift = UnityEngine.Random.insideUnitCircle * 0.25f;
        prab.transform.position += (Vector3)shift;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
