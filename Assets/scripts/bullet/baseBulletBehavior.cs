using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBulletBehavior : MonoBehaviour
{
    public float bulletSpeed =5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward*bulletSpeed*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
