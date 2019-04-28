using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodBehavior : Projectile
{
    public int lPowerHealth;
    
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Player") && !waitForDestroy)
        { 
            other.gameObject.GetComponent<Character>().hp -= damage;
            Destroy(gameObject, 0);
            Debug.Log(other.gameObject.GetComponent<Character>().hp ); 
        }

        if (other.gameObject.CompareTag("Player") && waitForDestroy)
        { 
            other.gameObject.GetComponent<Character>().hp += lPowerHealth;
            Destroy(gameObject, 0);
            Debug.Log(other.gameObject.GetComponent<Character>().hp ); 
        }

        if (other.gameObject.CompareTag("Floor"))
        {
            waitForDestroy = true;
            Destroy(gameObject, idleTime);
        }
    }
}
