using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {
    public bool moving = false;
    private Vector2 dir = new Vector2(0, 0);
    public Vector2 direct
    {
        set
        {
            dir = value.normalized;
        }
    }
    public float speed = 2;
    private float timeleft;
	// Use this for initialization
	void Start () {
		
	}
	public void keepMove(float time)
    {
        timeleft = time;
    }
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        if (moving && timeleft>=0)
        {
            Vector3 normalDir = ((Vector3)dir).normalized;
            transform.position += (normalDir)*speed*Time.deltaTime;
            //Debug.Log("normal:"+ normalDir+"速度:(" +normalDir.x * speed * 0.1f+","+ normalDir.y * speed * 0.1f);
        }
	}
}
