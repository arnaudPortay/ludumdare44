using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Character
{
    public GameObject player;
    public float smoothing = 5f;
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    new void  FixedUpdate()
    {
        base.FixedUpdate();
        // Create a vector from the player to the point on the floor the raycast from the mouse hit.
        Vector3 playerToMouse = player.transform.position - transform.position;       

        // Ensure the vector is entirely along the floor plane.
        playerToMouse.y = 0f;
        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
        Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);  

        //Debug.Log(transform.rotation + "    " + newRotatation);

        GetComponent<Rigidbody>().MoveRotation(newRotatation);
    }
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
