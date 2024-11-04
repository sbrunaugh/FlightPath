using UnityEngine;

public static class Extensions
{
    public static void Flatten(this Transform val)
    {
        val.rotation = new Quaternion()
        {
            x = 0,
            y = 0,
            z = 0,
            w = 0
        };
    }
}
