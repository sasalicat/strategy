using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_rot : missile {
    public float relativeZ = 0;//因為每張圖不一定都是指向前方的,所以需要一個固定的角度來調整
    // Update is called once per frame
    void Update () {//在基礎飛行的基礎上增加每幀轉向對準目標的功能
        if (traget!=null) {
            base.Update();
            float angle = AngleGetter.GetAnglefromZero3D(traget.transform.position - transform.position);//看看指向目標的向量和y向量的差角是多少

            transform.eulerAngles = new Vector3(0, 0, relativeZ - angle);
        }
    }
}
