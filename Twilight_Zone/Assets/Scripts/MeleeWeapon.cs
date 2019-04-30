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

    private void OnTriggerEnter(Collider other) 
    {
        // Bug here, if we get into contact with the floor for example hit attack will never become false and we'll be able to juste move
        // to damage the wolves....
        if (!other.gameObject.CompareTag(gameObject.tag) && hitAttack == true && other.gameObject.GetComponent<Character>())
        {       
            other.gameObject.GetComponent<Character>().loseBlood(attackValue);  
            hitAttack = false;
        }
    }
}
