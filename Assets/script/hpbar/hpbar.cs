using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbar : MonoBehaviour {
    public GameObject owner;
    public Image blueBar;
    public Image redBar;
    private float hp;
    public float nowHp {
        set
        {
            if (value > maxHp)
            {
                hp = maxHp;
            }
            else if(value<0){
                hp = 0;
            }
            else
            {
                hp = value;
            }
        }
        get
        {
            return hp;
        }
    }//用浮点数是因为要计算%

    public float maxHp;
    public bool AsLocal = true;
    private RectTransform rtransform=null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rtransform != null)
        {
            Vector3 localPos = rtransform.position;
            float width = rtransform.rect.width;
            float percentage = nowHp / maxHp;
            rtransform.anchoredPosition = new Vector2(-width * (1 - percentage), 0);

            if (owner != null)
            {
                Vector3 ownerPos = owner.transform.position;
                transform.position = new Vector3(ownerPos.x, ownerPos.y + 2, ownerPos.z);

            }
        }
    }
    public void setHpbar(GameObject owner,float maxHp,bool AsLocal)
    {
        this.owner = owner;
        this.maxHp = maxHp;
        this.nowHp = maxHp;
        if (AsLocal)
        {
            rtransform = redBar.GetComponent<RectTransform>();
            blueBar.gameObject.SetActive(false);
        }
        else
        {
            rtransform = blueBar.GetComponent<RectTransform>();
            redBar.gameObject.SetActive(false);
        }
    }
}
