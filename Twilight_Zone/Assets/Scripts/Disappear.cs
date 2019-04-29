using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float LifeSpan = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LifeSpan -= Time.deltaTime;
        if (LifeSpan <= 0)
        {
            Destroy(gameObject,0);
        }
    }
}
