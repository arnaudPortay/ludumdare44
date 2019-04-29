using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Character
{
    protected override void launchThrowAnimation()
    {                
        anim.SetTrigger("Throw");
    }

    public virtual void cycleThroughAnimations()
    {
        AnimatorStateInfo lInfo = anim.GetCurrentAnimatorStateInfo(0);
        //lInfo.
    }
}
