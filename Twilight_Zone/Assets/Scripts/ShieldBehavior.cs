using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public bool activated = false;
    public int speed = 200;
    Canvas canvas;


    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        if (canvas!=null)
        {
            canvas.enabled = activated;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas!=null)
        {
            canvas.enabled = activated;

            if (activated)
            {
                canvas.transform.Rotate(0,speed * Time.deltaTime,0);
            }            
        }        
    }
}
