using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int hp;

    public int lMaximalHealth;

    public GameObject distanceWeapon; 
    public GameObject meleeWeapon;

    protected Animator anim;
    
    protected virtual void launchThrowAnimation()
    {
        if (anim == null)
        {
            anim = gameObject.GetComponent<Animator>();            
        }
    }

    protected void hit() 
    {

    }

    protected void shoot()
    {
        launchThrowAnimation();
        distanceWeapon.GetComponent <DistanceWeapon> ().shoot();
    }

    virtual public void loseBlood(int damage)
    {
        hp -= damage;
    }

    virtual public void gainBlood(int healthPower)
    {
        hp += healthPower;
    }


}
