using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhant : canDrag {
    public int actionNo;
    public int traget_kind = 3;
    public ActionCard card = null;

    private GameObject getTraget()
    {
         
        List<GameObject> list= RayCaster.main.castBoxAt(transform.position, 2);
        Debug.Log("進入 getTraget 結果數量:"+list.Count);
        GameObject ans = null;
        foreach (GameObject obj in list)
        {
            Debug.Log("obj tag"+obj.tag);
            if (ans == null || (ans.transform.position - transform.position).magnitude >(obj.transform.position-transform.position).magnitude) {
                if (traget_kind == ActionCard.TO_ROLE || traget_kind == ActionCard.TO_ALL)
                {
                    if (obj.tag == "role")
                    {
                        Debug.Log("在role中:"+obj);
                        ans = obj;
                    }
                }else if (traget_kind== ActionCard.TO_TRAP || traget_kind == ActionCard.TO_ALL)
                {
                    if(obj.tag == "trap")
                    {
                        ans = obj;
                    }
                }
            }
        }
        
        return ans;
    }
    public override void onDraging()
    {
        base.onDraging();
        transform.position = mouseListener.translateMouse();
        //GameObject traget= getTraget();
        //traget
    }
    public override void onRelese()
    {
        base.onRelese();
        card.action(getTraget());
        Destroy(gameObject);
    }

}
