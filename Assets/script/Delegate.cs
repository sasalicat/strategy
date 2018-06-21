using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate {
    //用来统一委派(delegate)格式的档案
    public delegate void withGameObject(GameObject gobj);
    public delegate void withColor(Color nowcolor);
    public delegate void withNothing();
    public delegate void withList(List<object> list);
    public delegate void withInt32(System.Int32 arg);
    public delegate void withV2andGameObj(Vector2 v2, GameObject gameObj);
}
