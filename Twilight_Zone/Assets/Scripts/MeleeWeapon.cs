using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{   
    bool hitAttack = false;

    private void Awake() 
    {
        Init();
    } 
    public void hit()
    {        
        //if (timer >= attackRate)
       // {
            Debug.Log("ATTACK");
            hitAttack = true;
            /*
            Vector3 normalizedThrow = transform.TransformVector(ThrowDirection).normalized;
            GameObject ltest = Instantiate(projectile, transform.position+ normalizedThrow*offset, transform.rotation);
            Projectile lTestProjectile = ltest.GetComponent<Projectile>();
            lTestProjectile.damage = attackValue;
            lTestProjectile.shoot(normalizedThrow*1000);
            timer = 0.0f;   
            */ 
                
        //}
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy") && hitAttack == true)
        {       
            Debug.Log("Test de l'attaque");
            other.gameObject.GetComponent<Character>().loseBlood(attackValue);
            //Debug.Log(other.gameObject.GetComponent<Character>().hp );    
        }
    }
}
