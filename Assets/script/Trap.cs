using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour {
    public abstract void onInit(int ownerId);
    public virtual void befDestory()
    {

    }
    public virtual void effective(object arg)
    {

    }

}
