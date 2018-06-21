using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {
    public static RayCaster main;
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    public  List<GameObject> castBoxAt(Vector2 pos,float radiu)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        mousePos.z = 0;
        RaycastHit2D[] ans = Physics2D.BoxCastAll(mousePos, new Vector2(2, 2), 0, Vector2.zero);
        List<GameObject> realans= new List<GameObject>();
        foreach (RaycastHit2D traget in ans)
        {
            realans.Add(traget.transform.gameObject);
        }
        return realans;
    }
    public  List<GameObject> castGrid(Vector2 mousePos)
    {
        
        RaycastHit2D[] ans = Physics2D.RaycastAll(mousePos, transform.forward,10,256);
        List<GameObject> realans = new List<GameObject>();
        foreach (RaycastHit2D traget in ans)
        {
            realans.Add(traget.transform.gameObject);
        }
        return realans;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      /*   if (Input.GetMouseButtonDown(0))
         {
             Vector3 mousePos = Input.mousePosition;
             mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
             mousePos.z = -1;
             Debug.Log("mousePos:" + mousePos);
             Debug.DrawRay(mousePos, transform.forward, Color.red, 10);
             RaycastHit2D hit;
             if (hit = Physics2D.Raycast(mousePos, transform.forward, 10))
                 Debug.Log(hit.collider.name);
         }
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            mousePos.z = 0;
            List<GameObject> ans= castGrid(mousePos);
            Debug.Log("找到"+ans.Count+"个物件");
        }*/
    }
}
