using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// REFERENCE: https://www.youtube.com/watch?v=1h2yStilBWU&ab_channel=RenaissanceCoders
public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabs;
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        // prefabs = GetComponents<GameObject>();
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        var randIdx = Random.Range(0, prefabs.Length);
        spawnee = prefabs[randIdx];
        // Debug.Log("SPAWNING: " + spawnee.name);
        Vector3 randSpawnPostion = transform.position;
        Debug.Log(randSpawnPostion);
        randSpawnPostion.y += Random.Range(-1f, 1f);
        GameObject temp = Instantiate(spawnee, transform.position, transform.rotation);
        temp.transform.parent = gameObject.transform;
        temp.transform.position = randSpawnPostion;

    }
}
