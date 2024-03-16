using System;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }

    public static int GetCurrentScreenWidth()
    {
        Debug.Log(Screen.width);
        return Screen.width;
    }
}
