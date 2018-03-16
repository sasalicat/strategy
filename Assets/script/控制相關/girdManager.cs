using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle
{
    public float x = 0;
    public float y = 0;
    public float width = 0;
    public float height = 0;
    public Rectangle(float x,float y,float width,float height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
}
public class contain
{
    public GameObject land;
    public GameObject owner;
    public contain(GameObject land,GameObject owner)
    {
        this.land = land;
        this.owner = owner;
    }
    public contain(GameObject land)
    {
        this.land = land;
        this.owner = null;
    }
}
class girdGroup
{
    private sbyte mode = 1;
    public contain[,] girds;
    public Vector2 beginPoint;
    public Vector2 everyDistant;
    public Vector2 num;
    private girdManager manager;
    public void clearGrids()
    {
        foreach (contain g in girds)
        {
            manager.destoryObj(g.land);
        }
        girds = null;
    }
    public girdGroup(girdManager manager, GameObject gridItem, float beginX, float beginY, float distantX, float distantY, int xnum, int ynum)//用於畫矩形場地
    {
        this.manager = manager;
        beginPoint = new Vector2(beginX, beginY);
        everyDistant = new Vector2(distantX, distantY);
        num = new Vector2(xnum, ynum);

        this.girds = new contain[(int)num.y, (int)num.x];
        for (int y = 0; y < num.y; y++)
        {
            for (int x = 0; x < num.x; x++)
            {
                GameObject obj = manager.createObj(gridItem, new Vector3(beginPoint.x + everyDistant.x * x, beginPoint.y + everyDistant.y * y, 0));
                obj.GetComponent<SpriteRenderer>().color = manager.color_origen;
                girds[y, x] = new contain(obj);
                //                Debug.Log("x=" + x + " y=" + y + " pos:" + new Vector3(beginPoint.x + everyDistant.x * x, beginPoint.y + everyDistant.y * y, 0));
            }
        }
        mode = 1;
    }
    public girdGroup(girdManager manager, GameObject gridItem, float beginX, float beginY, float distantX, float distantY, int xnum, int ynum, Rectangle[] hollows)
    {
        new girdGroup(manager, gridItem, beginX, beginY, distantX, distantY, xnum, ynum);
        for (int y = 0; y < girds.GetLength(0); y++)
        {
            for (int x = 0; x < girds.GetLength(1); x++)
            {
                float left = beginPoint.x + x * everyDistant.x;
                float down = beginPoint.y + y * everyDistant.y;

                foreach (Rectangle rect in hollows)
                {
                    if (left >= rect.x && left + distantX <= rect.x + rect.width && down >= rect.y && down + distantY <= rect.y + rect.height)
                    {
                        //鏤空工序
                        Debug.Log("left" + left + ",down" + down);
                        Debug.Log("rectx" + rect.x + " recty" + rect.y + " rectx+w" + (rect.x + rect.width) + "recty+h" + (rect.y + rect.height));
                        manager.destoryObj(girds[y, x].land);
                        girds[y, x] = null;
                    }
                }
            }
        }
        mode = 2;
    }
    public bool inside(Vector2 mousePos)
    {
        bool ans = false;
        Vector2 mainGridPos = getCenter(mousePos);
        int x = (int)mainGridPos.x;
        int y = (int)mainGridPos.y;
        if (x >= 0 && y >= 0 && x < num.x && y < num.y)
        {
            ans = true;
        }
        if (mode == 2 && ans)//如果以mode1的觀點來看成立,那就看看格子是不是被剔掉了
        {
            if (girds[y, x] == null)
            {
                ans = false;
            }
        }
        return ans;
    }
    public Vector2 getCenter(Vector2 pos)
    {

        return new Vector2((int)((pos.x - beginPoint.x + 0.5f * everyDistant.x) / everyDistant.x), (int)((pos.y - beginPoint.y + 0.5f * everyDistant.y) / everyDistant.y));

    }
    public Vector2 getRealCenter(Vector2 pos)
    {
        Vector2 indexs= getCenter(pos);
        return new Vector2(everyDistant.x * indexs.x + beginPoint.x - 0.5f * everyDistant.x, everyDistant.y * indexs.y + beginPoint.y - 0.5f * everyDistant.y);
    }
    public void turnGreen(Vector3 pos)
    {
        if (inside(pos))
        {
            Vector2 mainGridPos = getCenter(pos);
            Debug.Log("in turn green index is " + mainGridPos);
            if (mode == 1)
            {
                int x = (int)mainGridPos.x;
                int y = (int)mainGridPos.y;
                if (x >= 0 && y >= 0 && x < num.x && y < num.y)
                {
                    if (x == 0 && y == 0)
                    {
                        girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y, x].land);
                        return;
                    }
                    else if (x == 0)
                    {
                        girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y, x].land);
                        girds[y - 1, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y - 1, x].land);
                    }
                    else if (y == 0)
                    {
                        girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y, x].land);
                        girds[y, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y, x - 1].land);
                    }
                    else
                    {
                        girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                        manager.beDyed.Add(girds[y, x].land);
                        girds[y - 1, x].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                        manager.beDyed.Add(girds[y - 1, x].land);
                        girds[y, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                        manager.beDyed.Add(girds[y, x - 1].land);
                        girds[y - 1, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                        manager.beDyed.Add(girds[y - 1, x - 1].land);
                    }
                }
            }


            else if (mode == 2)
            {
                if (mainGridPos.x >= 0 && mainGridPos.y >= 0 && mainGridPos.x < num.x && mainGridPos.y < num.y)
                {
                    GameObject obj = girds[(int)mainGridPos.y, (int)mainGridPos.x].land;
                    if (obj != null)
                    {
                        obj.GetComponent<SpriteRenderer>().color = manager.color_establish;
                        manager.beDyed.Add(obj);
                    }
                }
            }
        }
    }
    public void roleIn(GameObject role)//创建role到地图上占用格子
    {
        Vector2 pos = role.transform.position;
        if (inside(pos))
        {
            Vector2 indexs = getCenter(pos);
            if (mode == 1)
            {
                girds[(int)indexs.y, (int)indexs.x].owner = role;
                if (indexs.y > 0)//左边格子检查
                {
                    girds[(int)indexs.y - 1, (int)indexs.x].owner = role;
                }
                if (indexs.x > 0)//下边格子检查
                {
                    girds[(int)indexs.y, (int)indexs.x-1].owner = role;
                }
                if(indexs.x>0 && indexs.y > 0)//左下格子检查
                {
                    girds[(int)indexs.y-1, (int)indexs.x-1].owner = role;
                }
            }
            else if (mode == 2)
            {
                girds[(int)indexs.y, (int)indexs.x].owner = role;
            }
        }
    }
}

public class girdManager : MonoBehaviour {
    public static girdManager main=null;
    public GameObject gridItem;
    //    private Vector2 beginPoint = new Vector2(-7f,-19f);
    //    private Vector2 everyDistant = new Vector2(2, 2);
    //    private Vector2 num = new Vector2(8, 8);
    float beginPointx;
    float beginPointy;
    float everyDistantx;
    float everyDistanty;
    int numx;
    int numy;
    public List<GameObject> beDyed=new List<GameObject>();
    public Color color_establish;
    public Color color_error;
    public Color color_origen;
    private sbyte mode = 1;
    private List<girdGroup> groups=new List<girdGroup>();
    // Use this for initialization
    public void aftRoleIn(GameObject roleObj)
    {
        foreach(girdGroup g in groups)
        {
            g.roleIn(roleObj);
        }

    }
    public void drawRectangle(float beginX,float beginY,float distantX,float distantY,int xnum,int ynum)
    {
        groups.Add(new girdGroup(this, gridItem, beginX, beginY, distantX, distantY, xnum, ynum));
    }
    public void drawHollow(float beginX, float beginY, float distantX, float distantY, int xnum, int ynum, Rectangle[] hollows)
    {
        groups.Add(new girdGroup(this, gridItem, beginX, beginY, distantX, distantY, xnum, ynum, hollows));
    }
    public void clearGirds()
    {
        foreach(girdGroup g in groups)
        {
            g.clearGrids();
        }
        groups.Clear();
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
    void Start ()
    {
        Rectangle[] rects =new Rectangle[1];
        rects[0] = new Rectangle(-1.3f,-3.5f,3,3.3f);
        WarFieldManager.manager.AfterCreateRole += aftRoleIn;
        //drawHollow(beginPoint.x, beginPoint.y, everyDistant.x, everyDistant.y, (int)num.x, (int)num.y, rects);

    }

    public Vector2 getRealCenter(Vector2 mousePos)
    {
        Vector2 anspos = mousePos;
        foreach(girdGroup g in groups)
        {
            Debug.Log("in realcenter inside is" + g.inside(mousePos));
            if (g.inside(mousePos))
            {
                anspos=g.getRealCenter(mousePos);
            }
        }
        return anspos;
    }
    public void turnGreen(Vector2 pos)
    {
        
        foreach (girdGroup g in groups)
        {
            Debug.Log("in turngreen inside is" + g.inside(pos));
            g.turnGreen(pos);
        }
    }
    public void reSetColor()
    {
        foreach(GameObject obj in beDyed)
        {
            if(obj!=null)
                obj.GetComponent<SpriteRenderer>().color = color_origen;
        }
        beDyed.Clear();
    }
    public void StartDraw()
    {
        drawRectangle(-7, -19, 2, 2, 8, 8);
        drawRectangle(-7, 5, 2, 2, 8, 8);
    }
    public GameObject createObj(GameObject praf,Vector3 pos)
    {
       return Instantiate(praf, pos, transform.rotation);
    }
    public void destoryObj(GameObject obj)
    {
        Destroy(obj);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
