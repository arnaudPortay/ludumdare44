using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Character
{
    protected override void launchThrowAnimation()
    {
        base.launchThrowAnimation();        
        anim.SetTrigger("Throw");
    }

    private void FixedUpdate() {        
        if (Input.GetKeyDown("space"))
            shoot();
    }
}
