using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float MaxHealth = 500f;
    public float Health=100f;
    public float damage= 10f;

    // public delegate void DammageTaken(float damageTaken);
    //public DammageTaken del_damageTaken;
    private PlayerMovement movementComponent;
    private PlayerUI UIComponent;
    private void Awake()
    {
        movementComponent = GetComponent<PlayerMovement>();
        if (movementComponent != null)
        {
            Debug.Log("on player");
            UIComponent =GetComponent<PlayerUI>();
        }
        else
        {
            Debug.Log("on enemy");
        }
    }
    private void Start()
    {
        //del_damageTaken += ExampleFunction1;
    }
    public void AcceptDamage()
    {
        if (movementComponent != null)
        {
            movementComponent.playerMovementDamageTakenSingle(damage);
        }
        if (UIComponent != null)
        {
            UIComponent.UpdateHealthBar(GetHealthRatio());
        }
        Health -= damage;

        if (Health <= 0)
        {
            death();
        }
    }
    public void AcceptDamage(float incomingDamage)
    {
        if (movementComponent != null)
        {
            movementComponent.playerMovementDamageTakenSingle(incomingDamage);
        }
        if (UIComponent != null)
        {
            UIComponent.UpdateHealthBar(GetHealthRatio());
        }
        Health -=incomingDamage;

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
