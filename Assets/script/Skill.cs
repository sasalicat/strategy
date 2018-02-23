using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill:MonoBehaviour {
    public sbyte index;//技能在角色身上的索引值
    public abstract void trigger(GameObject traget);//技能生效时呼叫
}
