using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour {
    public abstract sbyte no
    {
        get;
    }
    public abstract void onAdd();
    public abstract void onDelete();
    public abstract void onUpdate(float time);
}
