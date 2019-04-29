using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWeapon : Weapon
{
    public GameObject projectile;
    public Vector3 ThrowDirection;

    public float offset = 1f;
    private void Awake() 
    {
        Init();
    }
    public void shoot()
    {
        if (timer >= attackRate)
        {
            Vector3 normalizedThrow = transform.TransformVector(ThrowDirection).normalized;
            GameObject ltest = Instantiate(projectile, transform.position+ normalizedThrow*offset, transform.rotation);
            Projectile lTestProjectile = ltest.GetComponent<Projectile>();
            lTestProjectile.damage = attackValue;
            lTestProjectile.shoot(normalizedThrow*1000);
            timer = 0.0f;        
        }
    }
}
