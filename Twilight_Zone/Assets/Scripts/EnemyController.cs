using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject SpawnPoint = null;

    public GameObject EnemyType = null;

    public int MaxSpawRate = 5; // ennemies per second

    public int  MaxNbWaves = 3;

    public int MaxNbEnemies = 15;

    public int MaximalHealth = 160;

    public AnimationCurve DistributionCurve;

    public bool HasNoMoreWaves
    {
        get
        {
            return currentWaveIndex > MaxNbWaves;
        }
    }

    private float timer;

    public int currentWaveIndex = 0;

    public int currentLivingEnnemies
    {
        get
        {
            return enemies.transform.childCount;
        }
    }

    private List<int> nbMaxEnemiesPerWave = new List<int>();

    private bool needsSpawn = true;

    private GameObject enemies;
    public int currentEnnemiesSpawnedInWave=0;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject("Enemies");
        enemies.transform.parent = transform;
    }

    public void ActivateEnnemies(bool activate)
    {
        enemies.SetActive(activate);
    }

    public void InitWaves()
    {
        nbMaxEnemiesPerWave.Clear();
        //Init timer
        timer = 0.0f;

        for(int i = 0; i < MaxNbWaves; ++i)
        {
            float x = i > 0 ? 1.0f/(MaxNbWaves - i) : 0.0f;
            nbMaxEnemiesPerWave.Insert(nbMaxEnemiesPerWave.Count, (int) (MaxNbEnemies * DistributionCurve.Evaluate(x)));
        }

        //Debug.Log(nbMaxEnemiesPerWave.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if(HasNoMoreWaves)
        {
            return;
        }

        if(currentLivingEnnemies == 0 )//|| Input.GetMouseButtonDown(0))
        {
            currentWaveIndex ++;
            currentEnnemiesSpawnedInWave = 0;
        }        

        if(!HasNoMoreWaves && needsSpawn && nbMaxEnemiesPerWave.Count > 0 && currentEnnemiesSpawnedInWave < nbMaxEnemiesPerWave[currentWaveIndex])
        {
            currentEnnemiesSpawnedInWave++;
            GameObject enemy = Instantiate(EnemyType, randomizePosition(SpawnPoint.transform), transform.rotation);
            enemy.GetComponent<Enemy>().lMaximalHealth = MaximalHealth;
            enemy.transform.parent = enemies.transform;
            needsSpawn = false;
        }

        if(timer >= 1.0f / MaxSpawRate)
        {
            timer = 0.0f;
            needsSpawn = true;
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
