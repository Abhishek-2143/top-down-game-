using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ET1_Attack : MonoBehaviour
{
    EnemyBase baseEnemyScript;
    private bool canAttack;
    

    private void Awake()
    {
        baseEnemyScript = GetComponent<EnemyBase>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Instance == null)
        {
            return;
        }
        if (canAttack == false)
        {
            return;
        }
        if (baseEnemyScript.distanceToPlayer<0.3f) 
       {
            // baseEnemyScript.enemyTarget.GetComponent<HealthAndDamage>().AcceptDamage();
            
            PlayerMovement.Instance.GetComponent<HealthAndDamage>().AcceptDamage();

       }
        canAttack = false;
        StartCoroutine(AttackCooldown(1));
    }
    IEnumerator AttackCooldown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canAttack = true;
    }
}
