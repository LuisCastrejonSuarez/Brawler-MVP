using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera cam;
    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cam.fieldOfView = 100;
        }
        else
        {
            cam.fieldOfView = 45;
        }
    }
}
