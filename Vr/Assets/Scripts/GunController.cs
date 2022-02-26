using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnLoc;
    public float projectileSpeed = 10f;
    public float lifeTime = 3f;
    public InputActionReference toggleBulletReference;
    private bool bulletColBool = false;

    void Start()
    {
       toggleBulletReference.action.performed += BulletToggle;
    }
 
    void Update()
    {
 
    }
 
    void BulletToggle(InputAction.CallbackContext obj) {
        bulletColBool = !bulletColBool;
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.GetComponent<BulletController>().colDestroy = bulletColBool;
        projectile.transform.position = projectileSpawnLoc.position;
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(transform.eulerAngles.x+90, transform.eulerAngles.y, rotation.z);
        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawnLoc.forward * projectileSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyProjectile(projectile,lifeTime));
    }
 
    private IEnumerator DestroyProjectile(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }

 
}

