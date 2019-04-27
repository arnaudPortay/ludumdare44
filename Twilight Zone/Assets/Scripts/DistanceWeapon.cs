using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWeapon : Weapon
{
    public float idleTime;
    private Rigidbody rb;

    private void Awake() 
    {
        Init();
        rb = this.gameObject.GetComponent<Rigidbody>();        
    }
    public void shoot(Vector3 pForce)
    {
        if (timer >= attackRate)
        {
            rb.AddForce(pForce);
            timer = 0.0f;            
        }
    }
}
