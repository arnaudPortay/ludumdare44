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
        if (lInfo.IsName("Wave"))
        {
            anim.SetBool("ArmsUp", false);
        }
        else if (lInfo.IsName("LowerArms_001") || lInfo.IsName("StartingState"))
        {
            if (Random.value < 0.5f)
            {
                anim.SetTrigger("Fretillage");                
            }
            else
            {
                anim.SetBool("ArmsUp", true);                 
            }
        }
    }

    public void onArmsUpOver()
    {
        anim.SetTrigger("Waving");
    }
}
