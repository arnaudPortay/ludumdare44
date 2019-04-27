using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdManager : MonoBehaviour
{
    public float feedingRate;
    public string startingFoodName;

    public arena arena;

    public GameObject player; 
    private Object currentFoodType;
    private Object [] foodTypes;

    private GameObject dummyCharacter;

    private float timer = 0.0f;

    private void Awake() 
    {
        // Populate food types
        foodTypes = Resources.LoadAll("Prefabs/Food", typeof(GameObject));
        
        // Set initial current food type
        foreach (Object lFood in foodTypes)
        {
            if (lFood.name == startingFoodName)
            {
                currentFoodType = lFood;
            }
        }

        // @TODO Load empty character 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void FixedUpdate() 
    {
        timer += Time.fixedDeltaTime;

        if (timer >= feedingRate)
        {
            // Compute shooting direction
            Vector3 lTarget = new Vector3(
                Random.Range(arena.xmin, arena.xmax),
                Vector2.Distance(new Vector2(arena.xmin, arena.zmin), new Vector2(arena.xmax, arena.zmax) ),
                Random.Range(arena.zmin, arena.zmax)
            );

            lTarget.Normalize();
            
            // @TODO Shoot



            timer = 0.0f;
        }        
    }
}
