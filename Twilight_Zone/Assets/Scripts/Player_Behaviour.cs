using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : Character
{
    public float speed = 6f;   
    Vector3 movement;                   // The vector to store the direction of the player's movement.                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    public WaveletUI waveletUi;

    public bool dancing =false;

    void Awake ()
    {
        base.Awake();
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");
        playerRigidbody = GetComponent <Rigidbody> ();
        if 
            (waveletUi)
        {
            waveletUi.updateHealth();
        }
    }


    void FixedUpdate ()
    {
        base.FixedUpdate();
        if (Input.GetMouseButtonDown(1))
        {
           // Turn the player to face the mouse cursor.
           shoot();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            // Turn the player to face the mouse cursor.
            hit();
        }
        if (dancing)
        {
            return;
        }
        // Store the input axes.
        float h = Input.GetAxisRaw("Vertical");
        TurningToMouse();
        if 
            (h !=0)
        {
            // Move the player around the scene.
            Move (h);
        }
        // Animate the player.
        Animating (h);
    }


    void Move (float h)
    {
        // Set the movement vector based on the axis input.
        movement.Set (0f, 0f, h);
        
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = transform.TransformVector(movement).normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);

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


    void Animating (float h)
    {
        bool walking = h>0;
        bool backtrack = h<0;
        // Tell the animator whether or not the player is walking.
        anim.SetBool ("Running", walking);
        anim.SetBool ("BackTrack", backtrack);
    }


    override public void loseBlood(int damage)
    {
        base.loseBlood(damage);
        if (hp <= 0)
        {            
            //Destroy(gameObject,0);              
        }
        waveletUi.updateHealth();
    }

    override public void gainBlood(int healthPower)
    {   
        base.gainBlood(healthPower);

         if (hp > lMaximalHealth)
        {
            hp = lMaximalHealth;         
        }
        waveletUi.updateHealth();

    }

    protected override void launchThrowAnimation()
    {
        anim.SetTrigger("Spit");
    }

     protected override void launchHitAnimation()
    {
        anim.SetTrigger("RightAttack");
    }
}
