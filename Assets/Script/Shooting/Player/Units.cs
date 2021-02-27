using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Units
{
    public static float getAngle(Vector2 from, Vector2 to)
    {
        var dx = to.x - from.x;
        var dy = to.y - from.y;

        var deg = Mathf.Atan2(dy, dx);
        return deg * Mathf.Rad2Deg;
    }
}
