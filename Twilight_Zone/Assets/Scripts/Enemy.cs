using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     override public void loseBlood(int damage)
    {
        base.loseBlood(damage); 
        if (hp <= 0)
        {                 
            Destroy(gameObject,0);             
        }
    }
}
