using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int hp;

    public float timeImmunity = 1f;

    private float timerDamage = 0.0f;

    public int lMaximalHealth;

    public GameObject distanceWeapon; 
    public GameObject meleeWeapon;

    protected Animator anim;
    
    protected virtual void launchThrowAnimation()
    {

    }

    protected virtual void launchHitAnimation()
    {
        
    }


    protected void FixedUpdate() {
        timerDamage += Time.fixedDeltaTime;
    }

    protected void Awake() {
        if (anim == null)
        {
            anim = gameObject.GetComponent<Animator>();            
        }
    }
    protected void hit() 
    {
        // if (!isDistanceAttacking)
        // {
            launchHitAnimation();
            meleeWeapon.GetComponent <MeleeWeapon> ().hit();
        //}
        
    }

    protected void shoot()
    {
        launchThrowAnimation();
    }

    virtual public void loseBlood(int damage)
    {   Debug.Log("test - hp = " + hp);
        if (timerDamage >= timeImmunity)
        {
            hp -= damage;
            timerDamage = 0.0f;
            Debug.Log("hp = " + hp);
        }
    }

    virtual public void gainBlood(int healthPower)
    {
        hp += healthPower;
        Debug.Log("hp = " + hp);
    }


    public void onThrowOver()
    {
        Debug.Log("in");
        distanceWeapon.GetComponent <DistanceWeapon> ().shoot();
    }
}
