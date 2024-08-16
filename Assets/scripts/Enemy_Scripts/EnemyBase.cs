using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float enemySpeed;
    public float enemyCurrentHealth;
    public float enemyDamage;
    public float enemySize;
    public Transform enemyTarget;
    public float rotationspeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 direction = enemyTarget.position- transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationspeed*Time.deltaTime);

        transform.position=transform.position+ (transform.forward * enemySpeed * Time.deltaTime);

    }
}
