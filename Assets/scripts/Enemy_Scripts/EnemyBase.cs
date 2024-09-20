using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float enemySpeed;
    
    public Transform enemyTarget;
    public float rotationspeed;
    public float distanceToPlayer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget == null)
        {
            return;
        }
        distanceToPlayer= Vector3.Distance(transform.position, enemyTarget.position);   

        Vector3 direction = enemyTarget.position- transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationspeed*Time.deltaTime);

        transform.position=transform.position+ (transform.forward * enemySpeed * Time.deltaTime);

    }

    private void OnDestroy()
    {
        //Instantiate(xpobject, transform.position, transform.rotation);
    }
}
