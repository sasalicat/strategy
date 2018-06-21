using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntPair {
    public int x;
    public int y;
    public IntPair()
    {
        x = 0;
        y = 0;
    }
    public IntPair(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public static  IntPair operator + (IntPair one,IntPair two){
        return new IntPair(one.x + two.x, one.y + two.y);
    }
    public static IntPair operator -(IntPair one, IntPair two)
    {
        return new IntPair(one.x - two.x, one.y - two.y);
    }
    public static bool operator ==(IntPair one, IntPair two)
    {
        return one.x == two.x && one.y == two.y;
    }
    public static bool operator !=(IntPair one, IntPair two)
    {
        return !(one == two);
    }
    public override string ToString()
    {
        return "("+x + "," + y + ")";
    }
}
