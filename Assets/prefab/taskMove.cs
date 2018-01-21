using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskMove : MonoBehaviour {
    public float speed = 10;
    private Vector3 direct = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0&&Input.GetTouch(0).phase==TouchPhase.Began)
        {
            Vector3 point= Camera.main.WorldToScreenPoint(Input.GetTouch(0).position);
            Debug.Log("point is:" + point);
            direct = new Vector3(point.x, point.y).normalized;
        }
        transform.position += direct * Time.deltaTime;
	}
}
