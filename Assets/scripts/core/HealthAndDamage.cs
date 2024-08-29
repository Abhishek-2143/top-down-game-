using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float Health=100f;
    public float damage;

    public void AcceptDamage(float incomingDamage)
    {
        Health = Health- incomingDamage;

        if (Health < 0)
        {
            death();
        }
    }

    public void death()
    {

    }
}
