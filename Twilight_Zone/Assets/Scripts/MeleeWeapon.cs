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
        hitAttack = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy") && hitAttack == true)
        {       
            other.gameObject.GetComponent<Character>().loseBlood(attackValue);  
            hitAttack = false;
        }
    }
}
