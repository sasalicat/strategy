using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effection_sp : effection {
    public float relativeRota;
    public Vector2 relativeLocalPos;
    public virtual void onBeenCreated(GameObject traget,GameObject creater)
    {
        float oriAngle = AngleGetter.GetAnglefromZero3D(traget.transform.position - creater.transform.position);
        Debug.Log("在effection sp中 oriangle為"+oriAngle);
        float angle = relativeRota - oriAngle;
        Debug.Log("在effection sp中 angle為" + angle);
        Vector2 newrelPos = new Vector2(relativeLocalPos.x*Mathf.Cos(angle),relativeLocalPos.y*Mathf.Sin(angle));
        transform.position += (Vector3)newrelPos;
        transform.eulerAngles = new Vector3(0,0,angle);
    }
}
