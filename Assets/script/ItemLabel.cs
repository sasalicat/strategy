using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLabel : MonoBehaviour {
    public void delPhantasm_t(GameObject gobj)
    {
        Debug.Log("delPhantasm 被觸發");
        Phantasm script = gobj.GetComponent<Phantasm>();
        if (script != null)//確定是幻影
        {
            if (girdManager.main.Vaild(gobj.transform.position))
            {
                if (script.kind == Phantasm.TRAP)
                    WarFieldManager.manager.createTrap(script.roleNo, gobj.transform.position);
            }
            Debug.Log("删除幻影-陷阱");
            Destroy(gobj);
        }
    }
        // Use this for initialization
    void Start () {
        mouseListener.main.onReleaseDrag += delPhantasm_t;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
