﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Fig9 : MonoBehaviour
{
    // Declare a mover object
    private Mover1_9 mover;

    // Start is called before the first frame update
    void Start()
    {
        // Create a Mover object
        mover = new Mover1_9();
    }

    // Update is called once per frame forever and ever (until you quit).
    void Update()
    {
        mover.Step();
        mover.CheckEdges();
    }
}

public class Mover1_9
{
    // The basic properties of a mover class
    private Vector2 location, velocity, acceleration;
    private float topSpeed;

    // The window limits
    private Vector2 maximumPos;

    // Gives the class a GameObject to draw on the screen
    private GameObject mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);

    public Mover1_9()
    {
        FindWindowLimits();

        // Vector2.zero is shorthand for a (0, 0) vector
        location = Vector2.zero; 
        velocity = Vector2.zero;
        acceleration = Vector2.zero;

        // Set top speed to 2f
        topSpeed = 2f;

        //We need to create a new material for WebGL
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }

    public void Step()
    {
        // Random acceleration but it's not normalized
        acceleration = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        // Normalize the acceletation
        acceleration.Normalize();

        // Now we can scale the magnitude as we wish
        acceleration *= Random.Range(5f, 10f);

        // Speeds up the mover, Time.deltaTime is the time passed since the last frame and ties acceleration to a fixed rate instead of framerate
        velocity += acceleration * Time.deltaTime;

        // Limit Velocity to the top speed
        velocity = Vector2.ClampMagnitude(velocity, topSpeed);

        // Moves the mover
        location += velocity * Time.deltaTime;

        // Updates the GameObject of this movement
        mover.transform.position = new Vector2(location.x, location.y);
    }

    public void CheckEdges()
    {
        if (location.x > maximumPos.x)
        {
            location.x = -maximumPos.x;
        }
        else if (location.x < -maximumPos.x)
        {
            location.x = maximumPos.x;
        }
        if (location.y > maximumPos.y)
        {
            location.y = -maximumPos.y;
        }
        else if (location.y < -maximumPos.y)
        {
            location.y = maximumPos.y;
        }
    }

    private void FindWindowLimits()
    {
        // We want to start by setting the camera's projection to Orthographic mode
        Camera.main.orthographic = true;

        // For FindWindowLimits() to function correctly, the camera must be set to coordinates 0, 0 for x and y. We will use -10 for z in this example
        Camera.main.transform.position = new Vector3(0, 0, -10);

        // Next we grab the maximum position for the screen
        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}




