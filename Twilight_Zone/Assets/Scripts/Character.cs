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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FixedUpdate() {
        timerDamage += Time.fixedDeltaTime; 
    }

    protected void hit() 
    {
        meleeWeapon.GetComponent <MeleeWeapon> ().hit();
    }

    protected void shoot()
    {
        distanceWeapon.GetComponent <DistanceWeapon> ().shoot();
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


}
