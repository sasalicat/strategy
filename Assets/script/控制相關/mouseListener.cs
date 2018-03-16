using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseListener : MonoBehaviour {
    public static mouseListener main;
    public bool clicking = false; 
    public GameObject dragObj=null;
    public Vector2 lastMouesPos;
    public Vector2 nowMousePos;
    public Vector2 ScreenSize;//用世界座標換算後的屏幕大小
    public const float BOUNDARY_WIDTH = 16;
    public const float BOUNDARY_HEIGHT = 22.5f;
    public Delegate.withGameObject onReleaseDrag=null;
	// Use this for initialization
    public static Vector2 translateMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
	void Start () {
		
        nowMousePos = translateMouse();
        Vector2 ur_point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2 zero_point = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        print("point up location" + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0)));
        print("point 0 location" + Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)));
        ScreenSize = new Vector2(ur_point.x - zero_point.x, ur_point.y - zero_point.y);

    }
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
    // Update is called once per frame
    void Update () {
        nowMousePos = translateMouse();
        girdManager g = girdManager.main;
        g.reSetColor();
        if (Input.GetMouseButton(0))
        {
            clicking = true;
        }
        else
        {
            clicking = false;
        }
        if (!clicking)
        {
            //Debug.Log("沒有clicking");
            if(dragObj != null)
            {
                onReleaseDrag(dragObj);
                dragObj = null;
            }
        }
        //拖動鏡頭=點擊+沒有點擊在角色上-----------------------------------------
        else if(dragObj==null)
        {//
         //
            Debug.Log("enter drug|||||||||||");
            Vector2 arraw= nowMousePos - lastMouesPos;//上一帧和这一帧鼠标的位移
            float presu_x = Camera.main.transform.position.x + arraw.x;
            float presu_y = Camera.main.transform.position.y + arraw.y;
            //Debug.Log("presu_x+size:"+(presu_x + ScreenSize.x)+"presu_x-size:"+(presu_x - ScreenSize.x));
            if (presu_x + ScreenSize.x/2 < BOUNDARY_WIDTH && presu_x - ScreenSize.x/2 > -BOUNDARY_WIDTH && presu_y + ScreenSize.y/2 < BOUNDARY_HEIGHT && presu_y - ScreenSize.y/2 > -BOUNDARY_HEIGHT)//如果推定沒有超過邊界
            {
                Camera.main.transform.position += (Vector3)arraw;
            }
        }
        else
        {
            g.turnGreen(nowMousePos);
            Debug.Log("turn green end-------------------");
        }
        lastMouesPos = nowMousePos;
	}
}
