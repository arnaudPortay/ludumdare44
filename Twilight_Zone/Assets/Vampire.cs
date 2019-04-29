using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Character
{
    protected override void launchThrowAnimation()
    {
        base.launchThrowAnimation();

        if (!anim.GetBool("ArmsUp"))
        {
            anim.SetBool("ArmsUp", true);
        }
    }
}
