﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float idleTime;
    private Rigidbody rb;

    private bool waitForDestroy;

    private void Awake() 
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        waitForDestroy = false;      
    }
    public void shoot(Vector3 pForce)
    {
        rb.AddForce(pForce);
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