using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ET1_Attack : MonoBehaviour
{
    EnemyBase baseEnemyScript;

    private float TimerValue;
    public float attackCooldown;
    private bool canAttack = false;

    private void Awake()
    {
        baseEnemyScript = GetComponent<EnemyBase>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        if (canAttack == false)
        {
            TimerValue = TimerValue + 0.02f; // TimerValue = 1 sec
            if (TimerValue > attackCooldown)
            {
                TimerValue = 0f;
                canAttack = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
    
        if (baseEnemyScript.distanceToPlayer<1f && canAttack == true) 
        {
            // baseEnemyScript.enemyTarget.GetComponent<HealthAndDamage>().AcceptDamage();
            float outGoingDamage = GetComponent<HealthAndDamage>().damage;
            PlayerMovement.Instance.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(outGoingDamage);
           
            canAttack = false;

            baseEnemyScript.enemySpeed = 1;
        }
        
       
    }
   

}
