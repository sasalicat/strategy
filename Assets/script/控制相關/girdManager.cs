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
}

public class girdManager : MonoBehaviour {
    public static girdManager main=null;
    public GameObject gridItem;
    private Vector2 beginPoint = new Vector2(-7f,-19f);
    private Vector2 everyDistant = new Vector2(2, 2);
    private Vector2 num = new Vector2(8, 8);
    private GameObject[,] grids;
    private List<GameObject> beDyed=new List<GameObject>();
    public Color color_establish;
    public Color color_error;
    public Color color_origen;
    private sbyte mode = 1;
    // Use this for initialization
    
    public void drawRectangle(float beginX,float beginY,float distantX,float distantY,int xnum,int ynum)
    {
        beginPoint = new Vector2(beginX, beginY);
        everyDistant = new Vector2(distantX, distantY);
        num = new Vector2(xnum, ynum);
        if (main != null)
        {
            Destroy(gameObject);
        }
        else
        {
            main = this;
        }
        this.grids = new GameObject[(int)num.y, (int)num.x];
        for (int y = 0; y < num.y; y++)
        {
            for (int x = 0; x < num.x; x++)
            {
                GameObject obj = Instantiate(gridItem, new Vector3(beginPoint.x + everyDistant.x * x, beginPoint.y + everyDistant.y * y, 0), transform.rotation);
                obj.GetComponent<SpriteRenderer>().color = color_origen;
                grids[y, x] = obj;
                //                Debug.Log("x=" + x + " y=" + y + " pos:" + new Vector3(beginPoint.x + everyDistant.x * x, beginPoint.y + everyDistant.y * y, 0));
            }
        }
        mode = 1;
    }
    public void drawHollow(float beginX, float beginY, float distantX, float distantY, int xnum, int ynum, Rectangle[] hollows)
    {
        drawRectangle(beginX, beginY, distantX, distantY, xnum, ynum);
        for(int y=0;y< grids.GetLength(0); y++)
        {
            for(int x = 0; x < grids.GetLength(1); x++)
            {
                float left = beginPoint.x + x * everyDistant.x;
                float down = beginPoint.y + y * everyDistant.y;

                foreach (Rectangle rect in hollows)
                {
                    if (left >= rect.x && left + distantX <= rect.x + rect.width && down >= rect.y && down + distantY <= rect.y + rect.height)
                    {
                        Debug.Log("left"+left+",down"+down);
                        Debug.Log("rectx" + rect.x + " recty" + rect.y + " rectx+w" + (rect.x + rect.width) + "recty+h" + (rect.y + rect.height)); 
                        Destroy(grids[y, x]);
                        grids[y, x] = null;
                    }
                }
            }
        }
        mode = 2;
    }
    public void clearGirds()
    {
        foreach(GameObject g in grids)
        {
            Destroy(g);
        }
        grids = null;
    }

    void Start ()
    {
        Rectangle[] rects =new Rectangle[1];
        rects[0] = new Rectangle(-1.3f,-3.5f,3,3.3f);
        //drawHollow(beginPoint.x, beginPoint.y, everyDistant.x, everyDistant.y, (int)num.x, (int)num.y, rects);
        drawRectangle(beginPoint.x, beginPoint.y, everyDistant.x, everyDistant.y, (int)num.x, (int)num.y);
    }
	public Vector2 getCenter(Vector2 pos)
    {
        //Debug.Log("posx:" + pos.x + " bx:" + beginPoint.x + " ans:" + ((int)(pos.x - beginPoint.x) / everyDistant.x));
        return new Vector2((int)((pos.x- beginPoint.x+ 0.5f*everyDistant.x) / everyDistant.x),(int)((pos.y-beginPoint.y+ 0.5f*everyDistant.y) /everyDistant.y));
    }
    public Vector2 getRealCenter(Vector2 mousePos)
    {
        if (mousePos.x < beginPoint.x || mousePos.x > beginPoint.x + num.x * everyDistant.x || mousePos.y < beginPoint.y || mousePos.y > beginPoint.y + num.y * everyDistant.y)
        {
            return mousePos;
        }
        else
        {
            Vector2 Indexs = getCenter(mousePos);
            return new Vector2(beginPoint.x+Indexs.x*everyDistant.x-0.5f*everyDistant.x,beginPoint.y+Indexs.y*everyDistant.y - 0.5f * everyDistant.y);
        }
    }
    public void turnGreen(Vector2 pos)
    {
        Vector2 mainGridPos = getCenter(pos);
        Debug.Log("in turn green index is " + mainGridPos);
        Debug.Log("in turn green pos is " + getRealCenter(pos));
        if (mode == 1)
        {
            int x = (int)mainGridPos.x;
            int y = (int)mainGridPos.y;
            if (x >= 0 && y >= 0 && x < num.x && y < num.y)
            {
                if (x == 0 && y == 0)
                {
                    grids[y, x].GetComponent<SpriteRenderer>().color = color_error;
                    beDyed.Add(grids[y, x]);
                    return;
                }
                else if (x == 0)
                {
                    grids[y, x].GetComponent<SpriteRenderer>().color = color_error;
                    beDyed.Add(grids[y, x]);
                    grids[y - 1, x].GetComponent<SpriteRenderer>().color = color_error;
                    beDyed.Add(grids[y - 1, x]);
                }
                else if (y == 0)
                {
                    grids[y, x].GetComponent<SpriteRenderer>().color = color_error;
                    beDyed.Add(grids[y, x]);
                    grids[y, x - 1].GetComponent<SpriteRenderer>().color = color_error;
                    beDyed.Add(grids[y, x - 1]);
                }
                else
                {
                    grids[y, x].GetComponent<SpriteRenderer>().color = color_establish;
                    beDyed.Add(grids[y, x]);
                    grids[y - 1, x].GetComponent<SpriteRenderer>().color = color_establish;
                    beDyed.Add(grids[y - 1, x]);
                    grids[y, x - 1].GetComponent<SpriteRenderer>().color = color_establish;
                    beDyed.Add(grids[y, x - 1]);
                    grids[y - 1, x - 1].GetComponent<SpriteRenderer>().color = color_establish;
                    beDyed.Add(grids[y - 1, x - 1]);
                }
            }
        }
        else if (mode == 2)
        {
            if (mainGridPos.x >= 0 && mainGridPos.y >= 0 && mainGridPos.x < num.x && mainGridPos.y < num.y)
            {
                GameObject obj = grids[(int)mainGridPos.y, (int)mainGridPos.x];
                if (obj != null)
                {
                    obj.GetComponent<SpriteRenderer>().color = color_establish;
                    beDyed.Add(obj);
                }
            }
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
	// Update is called once per frame
	void Update () {
		
	}
}
