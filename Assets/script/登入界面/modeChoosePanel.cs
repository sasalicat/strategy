using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class modeChoosePanel : MonoBehaviour {
    public List<GameObject> setActiveTrues;
    public List<GameObject> setActiveFalses;
    public static bool changeScene = false;
    private void setObjActive()
    {
        foreach(GameObject obj in setActiveTrues)
        {
            obj.SetActive(true);
        }
        foreach(GameObject obj in setActiveFalses)
        {
            obj.SetActive(false);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (changeScene)
        {
            Application.LoadLevel("one");
            
        }
	}
    public void matchBegin()
    {
        KBEngine.KBEngineApp.app.player().baseCall("startMatching", new object[] {});
        setObjActive();
    }
    public void debugModeStart()
    {
        KBEngine.KBEngineApp.app.player().baseCall("startDebugMode", new object[] { });
        setObjActive();
    }
}
