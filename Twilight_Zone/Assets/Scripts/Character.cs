using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float hp = 100f;
    public GameObject distanceWeapon; 
    public GameObject meleeWeapon;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void hit() 
    {

    }

    protected void shoot()
    {
        distanceWeapon.GetComponent <DistanceWeapon> ().shoot();
    }
}
