using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : effection{
    public delegate void SimpleDele();
    public GameObject traget = null;
    public float speed = 5;
    public SimpleDele onHitTraget;
	
	// Update is called once per frame
	protected void Update () {
        if (traget != null)
        {
            Vector3 toTraget = traget.transform.position - transform.position;
            if (toTraget.magnitude > speed * Time.deltaTime)
            {//这一帧还不能达到目标
                transform.position += toTraget.normalized * speed * Time.deltaTime;
            }
            else
            {
                transform.position = traget.transform.position;
                if (onHitTraget != null)
                   onHitTraget();
            }
        }
	}
}
