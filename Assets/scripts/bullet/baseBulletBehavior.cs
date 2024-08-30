using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBulletBehavior : MonoBehaviour
{
    public float bulletSpeed =5f;
    public Rigidbody bulletRigidbody;
    private Vector3 direction;
    public float BulletDamage = 5f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        bulletRigidbody.AddForce(direction * bulletSpeed);
        RaycastHit rayhit;
        if (Physics.Raycast(transform.position, bulletRigidbody.velocity.normalized,out rayhit, bulletRigidbody.velocity.magnitude * 0.02f))
        {
            rayhit.transform.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(BulletDamage);
            Destroy(gameObject);
        }
       
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(BulletDamage);
        Destroy(gameObject);
        Debug.Log("collision works");
    }

    
    public void SetBulletDirection(Vector3 desiredDirection)
    {
        direction = desiredDirection;
    }
}
