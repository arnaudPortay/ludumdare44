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

    public AnimationCurve DistributionCurve;

    public bool HasNoMoreWaves
    {
        get
        {
            return currentWaveIndex >= MaxNbWaves;
        }
    }

    private float timer;

    private int currentWaveIndex = 0;

    private List<GameObject> currentLivingEnnemies = new List<GameObject>();

    private List<int> nbMaxEnemiesPerWave = new List<int>();

    private bool needsSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    protected void Init()
    {
        //Init timer
        timer = 0.0f;

        for(int i = 0; i < MaxNbWaves; ++i)
        {
            float x = i > 0 ? 1.0f/(MaxNbWaves - i) : 0.0f;
            nbMaxEnemiesPerWave.Insert(nbMaxEnemiesPerWave.Count, (int) (MaxNbEnemies * DistributionCurve.Evaluate(x)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HasNoMoreWaves)
        {
            return;
        }

        if(currentLivingEnnemies.Count == 0 || Input.GetMouseButtonDown(0))
        {
            currentWaveIndex++;
        }

        if(needsSpawn && currentLivingEnnemies.Count < nbMaxEnemiesPerWave[currentWaveIndex])
        {
            GameObject enemy = Instantiate(EnemyType, randomizePosition(SpawnPoint.transform), transform.rotation);
            currentLivingEnnemies.Insert(currentLivingEnnemies.Count, enemy);
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
