using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantasm : canDrag{
    public const sbyte ROLE = 0;
    public const sbyte TRAP = 1;
    public sbyte roleNo;
    public sbyte radiu = 2;
    public sbyte kind = ROLE;
    List<GameObject> lastGreen=new List<GameObject>();
    public override void onDraging()
    {
        base.onDraging();
        girdManager.main.reSetColorList(lastGreen);
        if (radiu == 2)
        {
            Vector2 centerPos = girdManager.main.getRealCenter(mouseListener.translateMouse());
            girdManager.main.radiu = radiu;
            lastGreen= girdManager.main.turnGreen(mouseListener.translateMouse());
            //print("在幻影中real center is " + centerPos);
            transform.position = centerPos;
        }
        else if (radiu == 1)
        {
            Vector2 centerPos = girdManager.main.getRealCenter(mouseListener.translateMouse(), 1);
            girdManager.main.radiu = radiu;
            lastGreen= girdManager.main.turnGreen(mouseListener.translateMouse());
            print("在幻影中real center is " + centerPos);
            transform.position = centerPos;
        }
    }
    public override void onRelese()
    {
        base.onRelese();
        if (kind == ROLE)
        {
            WarFieldManager.manager.createRole(roleNo,transform.position);
        }
        else if(kind == TRAP)
        {
            WarFieldManager.manager.createTrap(roleNo,transform.position);
        }
        Destroy(gameObject);
    }
}
