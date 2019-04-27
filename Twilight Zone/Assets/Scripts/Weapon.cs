using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackValue;
    public float attackRate;

    protected float timer;


    // Start is called before the first frame update
    void Start()
    {        
    }

    protected void Init()
    {
        //Init timer
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() 
    {
        timer += Time.fixedDeltaTime;        
    }
}
