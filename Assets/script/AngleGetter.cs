using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleGetter  {
    public static float GetAnglefromZero3D(Vector3 vector)
    {
        vector.z = 0;
        float ans = Vector3.Angle(vector, Vector3.up);
        if (vector.x > 0)
        {
            return ans;
        }
        else
        {
           return 360 - ans;
        }
    }
}
