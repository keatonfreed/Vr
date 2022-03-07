using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 finalPos;
    public float startTime;
    public float spawnTime;
    private Rigidbody rb;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime)/spawnTime;
        if(t<=1) {
        // transform.position = Vector3.Lerp(startPos, finalPos, t);
        rb.MovePosition(Vector3.Lerp(startPos, finalPos, t));
        }
    }

    public void Spawned(Vector3 finalPos, float spawnTime) {
        startTime = Time.time;
        this.spawnTime = spawnTime;
        this.finalPos = finalPos;
        if(spawnTime == 0) {
        startPos = finalPos;
        } else {
        startPos = finalPos - new Vector3(0,150,0);
        }
        transform.position = startPos;
    }

    public void Fall() { 
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(0,200,0);
        // Destroy(prefab);
      StartCoroutine(Destroy(9f));
    }

    private IEnumerator Destroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
}
