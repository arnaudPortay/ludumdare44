using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    public GameObject distanceWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ltest = Instantiate(distanceWeapon, transform.position + new Vector3(0,0,1), transform.rotation);
            ltest.GetComponent<DistanceWeapon>().shoot(gameObject.transform.forward*1000);
        }
    }
}
