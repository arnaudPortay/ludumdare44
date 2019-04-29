﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : Character
{
    public float speed = 6f;   
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    public WaveletUI waveletUi;

    public bool dancing =false;

    void Awake ()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");
        // Set up references.
        anim = GetComponent <Animator> ();
        playerRigidbody = GetComponent <Rigidbody> ();
    }


    void FixedUpdate ()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Turn the player to face the mouse cursor.
           TurningToMouse();
           shoot();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // Turn the player to face the mouse cursor.
            TurningToMouse();
            hit();
        }
        if (dancing)
        {
            return;
        }
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move (h, v);
        // Animate the player.
        Animating (h, v);
    }


    void Move (float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set (h, 0f, v);
        
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);

        Turning (h,v);
    }


    void Turning (float h, float v)
    {
        if 
            (h != 0f || v != 0f)
        {
            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation (movement);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation (newRotatation);
        }
    }

    void TurningToMouse ()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;
            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation (newRotatation);
        }
    }


    void Animating (float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool ("Running", walking);
    }


    override public void loseBlood(int damage)
    {
        base.loseBlood(damage);
        if (hp <= 0)
        {            
            //Destroy(gameObject,0);               
        }
        Debug.Log("Damage = " + damage);
        Debug.Log("(-) hp = " + hp);
        waveletUi.updateHealth();
    }

    override public void gainBlood(int healthPower)
    {   
        base.gainBlood(healthPower);

         if (hp > lMaximalHealth)
        {
            hp = lMaximalHealth;         
        }
        Debug.Log("(+) hp = " + hp);
        waveletUi.updateHealth();

    }

}
