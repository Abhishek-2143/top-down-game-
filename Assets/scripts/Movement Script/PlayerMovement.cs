using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    Vector2 MovementValue = Vector2.zero;
    Vector2 loockingValue = Vector2.zero;
    public GameObject bulletPrefab;
 
    private GameObject bulletspwanedEnemy;

    private Vector3 bulletSpwanPosition;
    public float movementSpeed = 0.5f;
    public float forceAmount = 1;
    public float _mass = 20;
    public float TurnSpeed =1;
    public float shootingFrequency= 1f;
    public float bulletSpwanTimer = 0f;




    public Rigidbody Rb_Body;
    public void IAAccelerate(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();//<vector2> is a carats
        
    }

    public void IALoocking(InputAction.CallbackContext context)
    {
        loockingValue = context.ReadValue<Vector2>();
       
        Debug.Log(loockingValue);

        transform.Rotate(transform.up, loockingValue.x * Time.deltaTime* TurnSpeed);
        
    }
    public void IAShoot(InputAction.CallbackContext context)
    {
        bulletshoot();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

        transform.Translate(MovementValue.x * movementSpeed * Time.deltaTime, 0, MovementValue.y * movementSpeed * Time.deltaTime);//time.deltaTime is time take to r
       // Rb_Body.AddForce(MovementValue.x * movementSpeed * Time.deltaTime, 0, MovementValue.y * movementSpeed * Time.deltaTime);
        //Rb_Body.mass = _mass;
    }
    /*private void FixedUpdate()
    {
        bulletSpwanTimer = bulletSpwanTimer + 0.02f;
        if (bulletSpwanTimer >= shootingFrequency)
        {
            bulletSpwanTimer = 0;
            

        }
    }*/
    public void bulletshoot()
    {
        bulletspwanedEnemy = Instantiate(bulletPrefab, transform.position+transform.forward, Quaternion.identity);
    }



}
