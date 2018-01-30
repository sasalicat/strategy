using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using DG.Tweening;

public class EntityControl : MonoBehaviour {
    public Entity entity;
    public bool isPlayer = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("entity is" + entity);
        if (isPlayer&&entity != null)
        {
            Debug.Log("position is "+ entity.position);
            transform.position = entity.position;
            transform.eulerAngles = entity.direction;
        }
	}
    public void updatePosition(Vector3 newPos)
    {
        transform.DOMove(newPos, 0.1f);
    }
    public void updateRotation(Vector3 newRotat)
    {
        transform.eulerAngles = newRotat;
    }
    public void destorySelf()
    {
        GameObject.Destroy(gameObject);
    }
}
