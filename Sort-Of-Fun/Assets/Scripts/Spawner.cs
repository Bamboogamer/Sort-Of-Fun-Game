using UnityEngine;

// REFERENCE: https://www.youtube.com/watch?v=1h2yStilBWU&ab_channel=RenaissanceCoders
public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    
    public GameObject spawnedObj;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        var t = transform;
        var randIdx = Random.Range(0, prefabs.Length);
        Vector3 randSpawnPosition = transform.position;
        randSpawnPosition.y += Random.Range(-0.75f, 0.75f);
        randSpawnPosition.z = -5;
        
        spawnedObj = prefabs[randIdx];
        GameObject temp = Instantiate(spawnedObj, t.position, t.rotation);
        temp.transform.SetParent(gameObject.transform);
        temp.transform.position = randSpawnPosition;
        
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
