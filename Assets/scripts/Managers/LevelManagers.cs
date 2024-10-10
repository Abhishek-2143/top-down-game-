using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class LevelManagers : MonoBehaviour
{
    public static LevelManagers Instance;

    public Transform Player;
    public GameObject enemyToSpawn;
    private Vector3 enemySpwanPosition;
    
   
    private GameObject spwanedEnemy;
    public float enemySpwanFrequency = 1f;

    public float SpwanTimer = 0f;

    public float actualSpawnRadius;
    public float actualSpawnAngle;
    public float maxSpawnRadius;
    public float minSpawnRadius;
    
    public ParticleSystem BloodParticlesPrefab;
    private ParticleSystem spawndBloodParticlesSystem;

   

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        spawndBloodParticlesSystem = Instantiate(BloodParticlesPrefab); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        SpwanTimer = SpwanTimer + 0.02f; // spwan timer = 1 sec
        if (SpwanTimer >= enemySpwanFrequency)
        {
            SpwanTimer = 0;
            SpwanEnemy();
        }
    }
    void SpwanEnemy ()
    {
       

        actualSpawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);
        actualSpawnAngle = Random.Range(0, 360);
        enemySpwanPosition = new Vector3(actualSpawnRadius * Mathf.Cos(actualSpawnAngle), 0, actualSpawnRadius * Mathf.Sin(actualSpawnAngle));

        spwanedEnemy = Instantiate(enemyToSpawn,enemySpwanPosition,Quaternion.identity);
        spwanedEnemy.GetComponent<EnemyBase>().enemyTarget = Player;

    }
     
    public void SpawnBloodParticleAtLocation(Vector3 Location)
    {
        EmitParams bloodEmitParams = new EmitParams();
        bloodEmitParams.position = Location;
 
        spawndBloodParticlesSystem.Emit(bloodEmitParams,3);
        Debug.Log("Die");
        
    }
    

}
