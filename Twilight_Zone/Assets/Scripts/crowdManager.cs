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

    private float animChangeTimer = 0.0f;

    public int TimeBeforeAnimChange = 5;

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
       animChangeTimer += Time.fixedDeltaTime;

        if (animChangeTimer >= TimeBeforeAnimChange)
        {
            if (crowdMembers.Length > 0)
            {
                GameObject lCrowdMember = crowdMembers[Mathf.FloorToInt(Random.Range(0, crowdMembers.Length))];
                if (lCrowdMember)
                {
                    Vampire lCharaScript = lCrowdMember.GetComponent<Vampire>();
                    if (lCharaScript != null)
                    {                        
                        lCharaScript.cycleThroughAnimations();
                    }
                }
            }


            animChangeTimer = 0.0f;
        }  



        if (timer >= feedingRate)
        {
            // Get a random crowd member
            if (crowdMembers.Length > 0)
            {
                GameObject lCrowdMember = crowdMembers[Mathf.FloorToInt(Random.Range(0, crowdMembers.Length))];

                if (lCrowdMember)
                {
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
                    //lDirection.y = Mathf.Clamp(Vector3.Distance(lCrowdMember.transform.position, lTarget),5, 15) + Random.Range(0,maxInaccuracy);

                    // Compute shooting distance
                    Character lCharacter = lCrowdMember.GetComponent<Character>(); // Character script
                    DistanceWeapon lDistanceWeapon = lCharacter.distanceWeapon.GetComponent<DistanceWeapon>();
                    lDistanceWeapon.projectile = currentFoodType as GameObject;
                    lDistanceWeapon.ThrowDirection = -lDirection;

                    // shoot
                    lCrowdMember.GetComponent<Vampire>().shoot();
                }
            }
            timer = 0.0f;           
        }             
    }
}
