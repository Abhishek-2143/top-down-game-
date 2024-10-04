using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;


public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementValues = Vector2.zero;
    private Vector2 lookingValues = Vector2.zero;
    private HealthAndDamage hdComponent;
    private ParticleSystem muzzleParticleSystem;

    public GameObject bulletPrefab;
    public float PlayerSpeed = 100f;
    public Vector3 hitLocation;
    public bool canShoot = true;
    public float shootingCooldownTimer = 0.5f;
    public float SpwanTimer;
    public static PlayerMovement Instance;
    public float XP;

    public GameObject Muzzle_Flash_VFX;
    public GameObject Muzzle_location;

    public void IAAccelerate(InputAction.CallbackContext context)
    {
        movementValues = context.ReadValue<Vector2>();
    }

    public void IALooking(InputAction.CallbackContext context)
    {
        lookingValues = context.ReadValue<Vector2>();
    }

    public void IAShoot(InputAction.CallbackContext context)
    {
        //if (context.started == true)
        //{
        //   Shoot();
        //}
    }

    private void Awake()
    {
        if (Instance == null&& Instance != this)
        {
            Instance = this;
        }
        hdComponent = gameObject.GetComponent<HealthAndDamage>();

        GameObject muzzleVFXobject = Instantiate(Muzzle_Flash_VFX, Muzzle_location.transform.position, transform.rotation);
        muzzleParticleSystem = muzzleVFXobject.GetComponent<ParticleSystem>();
        muzzleParticleSystem.Stop();
        muzzleParticleSystem.transform.SetParent(transform);
    }

    void FixedUpdate()
    {
        SpwanTimer = SpwanTimer + 0.02f; // spwan timer = 1 sec
        if (SpwanTimer >= shootingCooldownTimer)
        {
            SpwanTimer = 0;
            Shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        // The reason I'm using this method is because transform.translate moves the player relative to its position and rotation.
        // This method moves the player relative to its position and does not take rotation into account
        // I find this method to be better during gameplay
        transform.position += new Vector3(movementValues.x * PlayerSpeed * Time.deltaTime, 0, movementValues.y * PlayerSpeed * Time.deltaTime);

        // Check where the mouse is pointing
        ProjectMouseToWorld();
        // Look at the mouse pointer
        transform.LookAt(hitLocation);
    }

    private void ProjectMouseToWorld()
    {
        Ray r = Camera.main.ScreenPointToRay(lookingValues);

        Plane playerPlane = new Plane(Vector3.up, transform.position);

        float entryDistance;

        if (playerPlane.Raycast(r, out entryDistance))
        {
            hitLocation = r.GetPoint(entryDistance);
        }
    }

    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }

        GameObject spawnedBullet;
        Vector3 direction = (hitLocation - transform.position).normalized;
        spawnedBullet = Instantiate(bulletPrefab, Muzzle_location.transform.position , Quaternion.identity);
        spawnedBullet.GetComponent<baseBulletBehavior>().SetBulletDirection(direction);
        spawnedBullet.GetComponent<baseBulletBehavior>().bulletDamage = hdComponent.damage;

        canShoot = false;
        StartCoroutine(ShootingCooldown(shootingCooldownTimer));

        EmitParams emitParams = new EmitParams();
        emitParams.position = muzzleParticleSystem.transform.position;

        muzzleParticleSystem.Emit(1);
    }

    // Coroutine to destroy the bullet after a specified number of seconds
    IEnumerator ShootingCooldown(float seconds)
    {
        // Waits for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        canShoot = true;
    }
    public void playerMovementDamageTakenSingle(float damage)
    {

    }


}
