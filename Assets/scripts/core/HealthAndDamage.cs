using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float MaxHealth = 500f;
    public float Health=100f;
    public float damage= 10f;

    delegate void DamageTakenDelegate(float _incomingDamage);

     DamageTakenDelegate delegate_DamageTaken;

    private void Start()
    {
        delegate_DamageTaken = AcceptDamage;
    }
    public void AcceptDamage(float incomingDamage)
    {
        Health = Health - incomingDamage;

        if (Health < 0)
        {
            death();
        }
        
    }

    public void death()
    {
        Debug.Log("enemy dies");
        Destroy(gameObject);
    }
     public float GetHealthRatio()
    {
        return Health/MaxHealth;
    }

   
}
