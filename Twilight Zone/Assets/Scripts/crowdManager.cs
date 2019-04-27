using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdManager : MonoBehaviour
{
    public float feedingRate;
    public string startingFoodName;
    public float maxInaccuracy;
    public GameObject[] crowdMembers;
    public GameObject player; 

    private Object currentFoodType;
    private Object [] foodTypes;
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
            // Get a random crowd member
            GameObject lCrowdMember = crowdMembers[Mathf.FloorToInt(Random.Range(0, crowdMembers.Length))];


            // Compute shooting direction
            Vector3 lTarget = new Vector3( 
                player.transform.position.x + Random.Range(-maxInaccuracy, maxInaccuracy),                
                player.transform.position.y,
                player.transform.position.z + Random.Range(-maxInaccuracy, maxInaccuracy)
            );

            Vector3 lDirection = lTarget - lCrowdMember.transform.position;
            lDirection.y = 0;
            lDirection.Normalize();
            // Set the y axis
            lDirection.y = Mathf.Clamp(Vector3.Distance(lCrowdMember.transform.position, lTarget),5, 15) + Random.Range(0,maxInaccuracy);
            
            // @TODO Uncomment once character
            // character lCharacter = lCrowdMember.GetComponent<character>(); // Character script
            // lCharacter.DistanceWeapon = Instantiate(currentFoodType, /*Hand position */, /* Hand Rotation */);
            // lCharacter.shoot();
            
            timer = 0.0f;
        }        
    }
}
