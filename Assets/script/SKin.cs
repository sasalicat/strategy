using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour {
    Color oriColor;
    private Color tragetColor;
    private Color speedColor;
    private float timeLeft = 0;
    private Delegate.withColor onFinish=null;
    public Delegate.withGameObject onDestory = null;
    private SpriteRenderer render;
	// Use this for initialization
	void Start () {

        render = GetComponent<SpriteRenderer>();
        oriColor = render.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            render.color += speedColor * Time.deltaTime;
            if (timeLeft <= 0)
            {
                if(onFinish!=null)
                    onFinish(render.color);
            }
        }
	}
    public void changeColor(Color newcolor, float time, Delegate.withColor finish)
    {
        if (onFinish != null && timeLeft>0)
            onFinish(render.color);
        Color nowcolor = GetComponent<SpriteRenderer>().color;
        speedColor = (newcolor - nowcolor) / time;
        timeLeft = time;
        onFinish = finish;

    }
    public void changeColor(Color newcolor,float time)
    {
        if (onFinish != null && timeLeft > 0)
            onFinish(render.color);
        Color nowcolor = GetComponent<SpriteRenderer>().color;
        speedColor = (newcolor - nowcolor) / time;
        timeLeft = time;
        onFinish = null;

    }
    public void revertColor()
    {
        render.color = oriColor;
    }
    private void diedEffect2(Color c)
    {
        c.a = 0;
        changeColor(c,0.7f,destorySelf);
    }
    public void diedEffect()
    {
        changeColor(Color.black, 0.3f, diedEffect2);
    }
    public void destorySelf(Color c)
    {
        if(onDestory !=null)
            onDestory(gameObject);
        Destroy(gameObject);
    }
}
