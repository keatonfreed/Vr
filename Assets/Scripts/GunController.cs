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
    public InputActionReference shootReference;
    private bool bulletColBool = false;

    void Start()
    {
    //    toggleBulletReference.action.performed += BulletToggle;
       shootReference.action.performed += Shoot;
       bulletColBool = true;
    }
 
    void Update()
    {
 
    }
 
    void BulletToggle(InputAction.CallbackContext obj) {
        bulletColBool = !bulletColBool;
    }

    public void Shoot(InputAction.CallbackContext obj)
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.GetComponent<BulletController>().colDestroy = bulletColBool;
        projectile.transform.position = projectileSpawnLoc.position;
        // projectile.transform.position = new Vector3(-5,-1,0);
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(transform.eulerAngles.x+90, transform.eulerAngles.y, rotation.z);
        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawnLoc.forward * projectileSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyProjectile(projectile,lifeTime));
        Debug.Log("shot");
    }
 
    private IEnumerator DestroyProjectile(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }

 
}

