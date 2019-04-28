using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWeapon : Weapon
{
    public GameObject projectile;
    public Vector3 ThrowDirection;
    private void Awake() 
    {
        Init();
    }
    public void shoot()
    {
        if (timer >= attackRate)
        {
            GameObject ltest = Instantiate(projectile, transform.position, transform.rotation);
            Projectile lTestProjectile = ltest.GetComponent<Projectile>();
            lTestProjectile.damage = attackValue;
            lTestProjectile.shoot(transform.TransformVector(ThrowDirection).normalized*1000);
            timer = 0.0f;        
        }
    }
}
