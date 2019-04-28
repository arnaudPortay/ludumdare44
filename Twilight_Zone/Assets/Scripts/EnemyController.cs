using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject SpawnPoint = null;

    public GameObject EnemyType = null;

    public int MaxSpawRate = 5; // ennemies per second

    public int  MaxNbWaves = 3;

    public bool NoMoreWaves
    {
        get
        {
            return currentWaveIndex == MaxNbWaves;
        }
    }

    private float timer;

    private int currentWaveIndex = -1;

    private List<GameObject> currentLivingEnnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    protected void Init()
    {
        //Init timer
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(NoMoreWaves)
        {
            return;
        }

        if(currentLivingEnnemies.Count == 0)
        {
            currentWaveIndex++;

            GameObject enemy = Instantiate(EnemyType, randomizePosition(transform), transform.rotation);
            currentLivingEnnemies.Insert(currentLivingEnnemies.Count, enemy);
        }
    }

    private Vector3 randomizePosition(Transform trsf)
    {
        return trsf.position;
    }
    private void FixedUpdate() 
    {
        timer += Time.fixedDeltaTime;        
    }
}
