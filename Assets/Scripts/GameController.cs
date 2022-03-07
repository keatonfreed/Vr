using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    private float nextPlatTime;
    public float platDelay = 5f;
    public GameObject platformPrefab;
    public GameObject startPlatformPrefab;
    private Vector3 nextPos;
    public int alivePlatformNum = 3;
    private float startDelay = 0;
    private float spawnTime = 4f;

    public GameObject player;

    public float score;

    // Start is called before the first frame update
    void Start()
    {
     nextPlatTime = Time.time + startDelay; 
     nextPos = new Vector3(0,-5,0);
     SpawnPlatform(true);
     score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextPlatTime) {
            SpawnPlatform();
        }

        if(player.transform.position.y <= nextPos.y - 200) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }
 
    void SpawnPlatform(bool firstPlatform = false) {
        var prefab = Instantiate(firstPlatform ? startPlatformPrefab : platformPrefab);
        prefab.GetComponent<PlatformController>().Spawned(nextPos,firstPlatform ? 0 : spawnTime);
        nextPos += new Vector3(Random.Range(-10f, 10f),Random.Range(-2f, 2.0f),Random.Range(-16f, -13f));
        nextPlatTime += platDelay;
        StartCoroutine(DestroyPlatform(prefab,(alivePlatformNum+1)*platDelay + (firstPlatform ? startDelay : 0)));
    }

    private IEnumerator DestroyPlatform(GameObject prefab, float delay)
    {
        yield return new WaitForSeconds(delay);
        prefab.GetComponent<PlatformController>().Fall();
        score++;
    }
}
