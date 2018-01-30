using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarFieldManager : MonoBehaviour {//管理场上角色的脚本
    public static WarFieldManager manager = null;
    public Dictionary<sbyte, GameObject> roles = new Dictionary<sbyte, GameObject>();
    // Use this for initialization
    protected  void Start () {
        if (manager != null && manager!=this)//如果已经有管理者存在,销毁自己
        {
            Destroy(this);
        }
        else
        {
            manager = this;
        }
	}
}
