using UnityEngine;

// REFERENCE: https://www.youtube.com/watch?v=1h2yStilBWU&ab_channel=RenaissanceCoders
public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabs;
    public GameObject spawnee;
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
        randSpawnPosition.y += Random.Range(-1.5f, 1.5f);
        
        spawnee = prefabs[randIdx];
        GameObject temp = Instantiate(spawnee, t.position, t.rotation);
        temp.transform.parent = gameObject.transform;
        temp.transform.position = randSpawnPosition;
        
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
