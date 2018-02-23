using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCreate : MonoBehaviour {
    public static FloatingCreate main;
    public const int GREEN_BEGIN = 10;
    public GameObject[] Numbers;
    public GameObject FloatingNumber;
	// Use this for initialization
	void Start () {
        if (main != null && main != this)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void createAt(int num,Vector3 pos)
    {
        bool hasNotZero = false;
        GameObject newone = Instantiate(FloatingNumber,pos,FloatingNumber.transform.rotation,gameObject.transform);
        for (int deno = 10000; deno>= 1; deno /=10)
        {

            int Index = num / deno;
// Debug.Log("deno" + deno + "index " + Index);
            if (Index != 0 || hasNotZero)
            {
                Instantiate(Numbers[Index], newone.transform);
                hasNotZero = true;
            }
            num = num % deno;

        }
    }
    public void createAt(int num, Vector3 pos,sbyte shift)
    {
        bool hasNotZero = false;
        GameObject newone = Instantiate(FloatingNumber, pos, FloatingNumber.transform.rotation, gameObject.transform);
        for (int deno = 10000; deno >= 1; deno /= 10)
        {

            int Index = num / deno;
            Debug.Log("deno" + deno + "index " + Index);
            if (Index != 0 || hasNotZero)
            {
                Instantiate(Numbers[Index+shift], newone.transform);
                hasNotZero = true;
            }
            num = num % deno;

        }
    }

}
