﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter6Fig1 : MonoBehaviour
{
    public Camera camera;
    public GameObject vehicle;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        vehicle = Instantiate(vehicle);
    }

    // Update is called once per frame
    void Update()
    {
        //set gameObject's position equal to the mouse's;
        target.transform.position = MousePosition(camera);
    }
    Vector2 MousePosition(Camera camera)
    {
        // Track the Vector2 of the mouse's position
        return camera.ScreenToWorldPoint(Input.mousePosition);        
    }
}
