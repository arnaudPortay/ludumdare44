using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWeapon : Weapon
{
    public float idleTime;
    private Rigidbody rb;

    private bool waitForDestroy;

    private void Awake() 
    {
        Init();
        rb = this.gameObject.GetComponent<Rigidbody>();
        waitForDestroy = false;      
    }
    public void shoot(Vector3 pForce)
    {
        if (timer >= attackRate)
        {
            rb.AddForce(pForce);
            timer = 0.0f;        
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy") && !waitForDestroy)
        {            
            Destroy(other.gameObject,1);
        }

        if (other.gameObject.CompareTag("Floor"))
        {
            waitForDestroy = true;
            Destroy(gameObject, idleTime);
        }
    }
}
