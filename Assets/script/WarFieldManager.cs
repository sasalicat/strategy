using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarFieldManager : MonoBehaviour {//管理场上角色的脚本
    public static WarFieldManager manager = null;
    public Dictionary<sbyte, GameObject> roles= new Dictionary<sbyte, GameObject>();
    public Dictionary<sbyte, GameObject> traps = new Dictionary<sbyte, GameObject>();
    public Delegate.withGameObject AfterCreateRole;
    public Delegate.withGameObject AfterCreateTrap;
    public Delegate.withInt32 RoundBegin;
    // Use this for initialization
    protected  void Start () {

	}
    void OnEnable() {
        if (manager != null && manager != this)//如果已经有管理者存在,销毁自己
        {
            Destroy(this);
        }
        else
        {
            manager = this;
        }
    }
    public virtual void createRole(sbyte rno,Vector2 pos)
    {
       
    }
    public virtual void createTrap(sbyte tno,Vector2 pos)
    {

    }

}
