using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool colDestroy = true;
    void OnCollisionEnter(Collision collision){
        if(colDestroy) {
            Destroy(gameObject);
        }
    }
}
