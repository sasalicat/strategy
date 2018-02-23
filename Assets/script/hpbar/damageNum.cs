using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageNum : MonoBehaviour {

    public const float EXIST_TIME = 0.8f;
    private float timeLeft = EXIST_TIME;
    public Vector3 speed = new Vector3(2, 2, 0);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        transform.position += speed * Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
	}
}
