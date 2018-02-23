using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBag : MonoBehaviour {
    public List<Skill> skillsInside;
    public void init(List<object> list)
    {
       // Debug.Log("in init " + gameObject.name);
        skillsInside = new List<Skill>();
        for(int i = 0; i < list.Count; i++)
        {
         //   print("type is " + list[i].GetType());
            string name = (skillNameList.main).skillNames[(byte)list[i]];
            skillsInside.Add((Skill)gameObject.AddComponent(System.Type.GetType(name)));
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
