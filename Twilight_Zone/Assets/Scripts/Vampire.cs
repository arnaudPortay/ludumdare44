using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Character
{
    protected override void launchThrowAnimation()
    {                
        anim.SetTrigger("Throw");
    }
}
