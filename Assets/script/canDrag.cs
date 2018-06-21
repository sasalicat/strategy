using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canDrag : MonoBehaviour {
    public virtual void onDraging()
    {

    }
    public virtual void onRelese()
    {

    }
    protected void Start()
    {
        mouseListener.main.onReleaseDrag += onRelese;
        
    }
    protected void OnDestroy()
    {
        mouseListener.main.onReleaseDrag -= onRelese;
    }
    protected void Update()
    {
        onDraging();
    }

}
