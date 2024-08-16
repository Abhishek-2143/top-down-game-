using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float enemySpwanFrequency = 1f;

    public float SpwanTimer = 0f;

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
        SpwanTimer = SpwanTimer + 0.02f;
        if (SpwanTimer >= enemySpwanFrequency)
        {
            SpwanEnemy();
        }
    }
    void SpwanEnemy ()
    {

    }

}
