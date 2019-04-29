using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodBehavior : Projectile
{
    public int lCarePower;
    
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Player") && !waitForDestroy)
        { 
            other.gameObject.GetComponent<Character>().loseBlood(damage);

            Destroy(gameObject, 0);

        }

        if (other.gameObject.CompareTag("Player") && waitForDestroy)
        { 
            other.gameObject.GetComponent<Character>().gainBlood(lCarePower);
            
            Destroy(gameObject, 0);
  
        }

        if (other.gameObject.CompareTag("Floor"))
        {
            waitForDestroy = true;
            Destroy(gameObject, idleTime);
        }
    }
}
