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
public class girdGroup
{
    private sbyte mode = 1;
    public contain[,] girds;
    public Vector2 beginPoint;
    public IntPair beginIndexs=new IntPair(0,0);
    public Vector2 everyDistant;
    public Vector2 num;
    private girdManager manager;
    /*public void onclick(int x,int y)
    {
        if(manager.onGirdClick!=null)
            manager.onGirdClick(x + (int)beginIndexs.x, y + (int)beginIndexs.y);
    }*/
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
                obj.GetComponent<gridItem>().init(x, y, this);
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
    public void setBeginIndexs(int x,int y)
    {
        this.beginIndexs = new IntPair(x, y);
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
    public bool valid(Vector2 mousePos)
    {
        Vector2 indexs = getCenter(mousePos);
        if (inside(mousePos))
        {
            if (mode == 1)
            {
                if (indexs.x > 0 && indexs.y > 0)
                {
                    if (girds[(int)indexs.y, (int)indexs.x].owner != null)
                    {
                        return false;
                    }
                    if (girds[(int)indexs.y, (int)indexs.x - 1].owner != null)
                    {
                        return false;
                    }
                    if (girds[(int)indexs.y - 1, (int)indexs.x].owner != null)
                    {
                        return false;
                    }
                    if (girds[(int)indexs.y - 1, (int)indexs.x - 1].owner != null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            else if (mode == 2)
            {
                if(girds[(int)indexs.y,(int)indexs.x].owner!=null)
                    return false;
                return true;
            }
        }
        return false;
    }
    public bool valid(Vector2 mousePos,GameObject ignore)
    {
        Vector2 indexs = getCenter(mousePos);
        if (inside(mousePos))
        {
            if (mode == 1)
            {
                if (indexs.x > 0 && indexs.y > 0)
                {
                    if (girds[(int)indexs.y, (int)indexs.x].owner != null && girds[(int)indexs.y, (int)indexs.x].owner != ignore)
                    {
                       
                        return false;
                    }
                    if (girds[(int)indexs.y, (int)indexs.x - 1].owner != null && girds[(int)indexs.y, (int)indexs.x-1].owner != ignore)
                    {
                        return false;
                    }
                    if (girds[(int)indexs.y - 1, (int)indexs.x].owner != null && girds[(int)indexs.y-1, (int)indexs.x].owner != ignore)
                    {
                        return false;
                    }
                    if (girds[(int)indexs.y - 1, (int)indexs.x - 1].owner != null && girds[(int)indexs.y-1, (int)indexs.x-1].owner != ignore)
                    {
                        return false;
                    }
                    return true;
                }
            }
            else if (mode == 2)
            {
                if (girds[(int)indexs.y, (int)indexs.x].owner != null)
                    return false;
                return true;
            }
        }
        return false;
    }
    public IntPair getIndexFor(Vector2 postion)
    {
        Debug.Log("beginIndex:"+ beginIndexs);
        Debug.Log("position:" + postion+"beginPoint"+beginPoint+"everyDistant"+everyDistant);
        return new IntPair((int)((postion.x - (beginPoint.x-1)) / everyDistant.x)+beginIndexs.x, 
            (int)((postion.y - (beginPoint.y-1)) / everyDistant.y)+beginIndexs.y);
    }
    public Vector2 getCenter(Vector2 pos)
    {

        return new Vector2((int)((pos.x - beginPoint.x + 0.5f * everyDistant.x) / everyDistant.x), (int)((pos.y - beginPoint.y + 0.5f * everyDistant.y) / everyDistant.y));

    }
    public Vector2 getRealCenter(Vector2 pos,int radiu)
    {
        if (radiu == 2)
        {
            return getRealCenter(pos);
        }
        else if(radiu == 1)
        {
            Vector2 indexs = getCenter(pos);
            return new Vector2(everyDistant.x * indexs.x + beginPoint.x, everyDistant.y * indexs.y + beginPoint.y);
        }
        return Vector2.zero;
    }
    public Vector2 getRealCenter(Vector2 pos)
    {
        Vector2 indexs= getCenter(pos);
        return new Vector2(everyDistant.x * indexs.x + beginPoint.x - 0.5f * everyDistant.x, everyDistant.y * indexs.y + beginPoint.y - 0.5f * everyDistant.y);
    }
    public List<GameObject> turnGreen(Vector3 pos)
    {
        List<GameObject> dyed = new List<GameObject>();
        if (inside(pos))
        {
            Vector2 mainGridPos = getCenter(pos);
            //Debug.Log("in turn green index is " + mainGridPos);
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
                        dyed.Add(girds[y, x].land);
                        return dyed;
                    }
                    else if (x == 0)
                    {
                        girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y, x].land);
                        dyed.Add(girds[y, x].land);

                        girds[y - 1, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y - 1, x].land);
                        dyed.Add(girds[y-1, x].land);
                        return dyed;
                    }
                    else if (y == 0)
                    {
                        girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y, x].land);
                        dyed.Add(girds[y, x].land);

                        girds[y, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                        manager.beDyed.Add(girds[y, x - 1].land);
                        dyed.Add(girds[y , x-1].land);
                        return dyed;
                    }
                    else
                    {
                        if (girds[y, x].owner == null)
                        {
                            girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                            manager.beDyed.Add(girds[y, x].land);
                        }
                        else
                        {
                            girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                            manager.beDyed.Add(girds[y, x].land);
                        }
                        dyed.Add(girds[y, x].land);
                        if (girds[y - 1, x].owner == null)
                        {
                            girds[y - 1, x].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                            manager.beDyed.Add(girds[y - 1, x].land);
                        }
                        else
                        {
                            girds[y - 1, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                            manager.beDyed.Add(girds[y - 1, x].land);
                        }
                        dyed.Add(girds[y-1, x].land);
                        if (girds[y, x - 1].owner == null)
                        {
                            girds[y, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                            manager.beDyed.Add(girds[y, x - 1].land);
                        }
                        else
                        {
                            girds[y, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                            manager.beDyed.Add(girds[y, x - 1].land);
                        }
                        dyed.Add(girds[y, x-1].land);
                        if (girds[y - 1, x - 1].owner == null)
                        {
                            girds[y - 1, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                            manager.beDyed.Add(girds[y - 1, x - 1].land);
                        }
                        else
                        {
                            girds[y - 1, x - 1].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                            manager.beDyed.Add(girds[y - 1, x - 1].land);
                        }
                        dyed.Add(girds[y-1, x-1].land);
                        return dyed;
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
                        dyed.Add(obj);
                        return dyed;
                    }
                }
            }
        }
        return dyed;
    }

    public List<GameObject> turnGreen(Vector3 pos,int radiu)
    {
        List<GameObject> dyed = new List<GameObject>();
        if (radiu == 2)
        {
            return turnGreen(pos);
        }

        else if (radiu == 1)
        {
            
            if (inside(pos))
            {
                Vector2 mainGridPos = getCenter(pos);
                //Debug.Log("in turn green index is " + mainGridPos);

                int x = (int)mainGridPos.x;
                int y = (int)mainGridPos.y;
                if (girds[y, x].owner == null)
                {
                    girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                    manager.beDyed.Add(girds[y, x].land);
                }
                else
                {
                    girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_error;
                    manager.beDyed.Add(girds[y, x].land);
                }
                dyed.Add(girds[y, x].land);
            }

        }
        return dyed;
    }
    public List<GameObject> turnGreenByIndexs(List<IntPair> map)
    {
        List<GameObject> dyed = new List<GameObject>();
        for(int y=0;y< girds.GetLength(0); y++)
        {
            for(int x = 0; x < girds.GetLength(1); x++)
            {
                foreach(IntPair pair in map)
                {
                    
                    var realPair = new IntPair(x,y) + beginIndexs;
                    //Debug.Log("realPair:" + realPair + "pair:" + pair);
                    if (realPair == pair)
                    {
                        Debug.Log("realPair:" + realPair);
                        girds[y, x].land.GetComponent<SpriteRenderer>().color = manager.color_establish;
                        manager.beDyed.Add(girds[y, x].land);
                        dyed.Add(girds[y, x].land);
                        break;
                    }
                }
            }
        }
        return dyed;
    }
    public List<GameObject> turnGreenByIndexs(List<IntPair> map,girdManager.turnGreenRequest function)
    {
        List<GameObject> dyed = new List<GameObject>();
        for (int y = 0; y < girds.GetLength(0); y++)
        {
            for (int x = 0; x < girds.GetLength(1); x++)
            {
                foreach (IntPair pair in map)
                {

                    var realPair = new IntPair(x, y) + beginIndexs;
                    //Debug.Log("realPair:" + realPair + "pair:" + pair);
                    if (realPair == pair)
                    {
                        Debug.Log("realPair:" + realPair);
                        girds[y, x].land.GetComponent<SpriteRenderer>().color =function(this, girds[y, x].land,pair);
                        manager.beDyed.Add(girds[y, x].land);
                        dyed.Add(girds[y, x].land);
                        break;
                    }
                }
            }
        }
        return dyed;
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
                Debug.Log("role in "+ indexs);
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
    public delegate void withXYNo(int x, int y);
    public delegate Color turnGreenRequest(girdGroup group, GameObject gird, IntPair indexs);
    //public withXYNo onGirdClick;
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
    public List<girdGroup> groups=new List<girdGroup>();
    public int radiu = 2;
    // Use this for initialization
    public void aftRoleIn(GameObject roleObj)
    {
        Debug.Log(">>>>>>>>进入 aftRoleIn:"+roleObj);
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
        WarFieldManager.manager.AfterTeleport += afterTP;
        //drawHollow(beginPoint.x, beginPoint.y, everyDistant.x, everyDistant.y, (int)num.x, (int)num.y, rects);

    }

    public Vector2 getRealCenter(Vector2 mousePos)
    {
        Vector2 anspos = mousePos;
        foreach(girdGroup g in groups)
        {
            //Debug.Log("in realcenter inside is" + g.inside(mousePos));
            if (g.inside(mousePos))
            {
                anspos=g.getRealCenter(mousePos);
            }
        }
        return anspos;
    }
    public Vector2 getRealCenter(Vector2 mousePos,int radiu)
    {
        if (radiu == 2)
        {
           return  getRealCenter(mousePos);
        }
        else if (radiu == 1)
        {
            Vector2 anspos = mousePos;
            foreach (girdGroup g in groups)
            {
                //Debug.Log("in realcenter inside is" + g.inside(mousePos));
                if (g.inside(mousePos))
                {
                    anspos = g.getRealCenter(mousePos,1);
                }
            }
            return anspos;
        }
        return Vector2.zero;
    }
    public List<GameObject> turnGreen(Vector2 pos)
    {
        List<GameObject> dyed = new List<GameObject>();
        foreach (girdGroup g in groups)
        {
            //Debug.Log("in turngreen inside is" + g.inside(pos));
            
            var ans= g.turnGreen(pos,radiu);
            foreach(GameObject obj in ans)
            {
                dyed.Add(obj);
            }
        }
        return dyed;
    }
    public List<GameObject> turnGreenByIndexs(List<IntPair> map)
    {
        List<GameObject> dyed = new List<GameObject>();
        foreach (girdGroup group in groups)
        {
            var ans= group.turnGreenByIndexs(map);
            foreach (GameObject obj in ans)
            {
                dyed.Add(obj);
            }
        }
        return dyed;
    }
    public List<GameObject> turnGreenByIndexs(List<IntPair> map,turnGreenRequest request)
    {
        List<GameObject> dyed = new List<GameObject>();
        foreach (girdGroup group in groups)
        {
            var ans = group.turnGreenByIndexs(map,request);
            foreach (GameObject obj in ans)
            {
                dyed.Add(obj);
            }
        }
        return dyed;
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
    public void reSetColorList(List<GameObject> list)
    {
        foreach (GameObject obj in list)
        {
            if (obj != null)
                obj.GetComponent<SpriteRenderer>().color = color_origen;
        }
    }
    public void StartDraw()
    {
        drawRectangle(-7, -19, 2, 2, 8, 18);

    }
    public bool Vaild(Vector2 mousePos)
    {
        bool ans = false;
        foreach(girdGroup g in groups)
        {
            if (g.valid(mousePos))
            {
                ans = true;
            }
        }
        return ans;
    }
    public IntPair getIndexs(Vector2 pos)
    {
        foreach (girdGroup g in groups)
        {
            if (g.inside(pos))
            {
                return g.getIndexFor(pos);
                
            }
        }
        return null;
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
    public void afterTP(Vector2 oripos, GameObject role)
    {
        foreach (girdGroup group in groups)
        {
            if (group.inside(oripos))
            {
                IntPair pair = group.getIndexFor(oripos);
                group.girds[pair.y, pair.x].owner = null;

                if (pair.x - 1 >= 0)
                {
                    group.girds[pair.y, pair.x-1].owner = null;
                }
                if (pair.y - 1 >= 0)
                {
                    group.girds[pair.y-1, pair.x].owner = null;
                }
                if (pair.y - 1 >= 0 && pair.x-1>=0)
                {
                    group.girds[pair.y - 1, pair.x-1].owner = null;
                }
            }
        }
        aftRoleIn(role);
    }
}
