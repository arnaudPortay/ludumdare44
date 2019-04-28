using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float hp = 100f;

    public int lMaximalHealth;

    public GameObject distanceWeapon; 
    public GameObject meleeWeapon;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
             if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject,0);
            }   

            if (gameObject.CompareTag("Player"))
            {
                // GAME END

            }              
        }

        //Maximal health
         if (hp > lMaximalHealth)
        {
             if (gameObject.CompareTag("Player"))
            {
                hp = lMaximalHealth;
            }          
        }
    }

    protected void hit() 
    {

    }

    protected void shoot()
    {
        distanceWeapon.GetComponent <DistanceWeapon> ().shoot();
    }

}
