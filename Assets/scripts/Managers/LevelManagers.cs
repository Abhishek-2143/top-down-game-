using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{
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

}
