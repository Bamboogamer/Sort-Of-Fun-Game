using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] public float speed = 0.25f; // Increase/Decrease based on Difficulty
    
    private List<Collider2D> objectsInBucket;
    
    void Start()
    {
        objectsInBucket = new List<Collider2D>();
    }

    private void Update()
    {
        for (var i = objectsInBucket.Count-1; i >= 0; i--)
        {
            OnTriggerStay2D(objectsInBucket[i]);
        }  
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.GetComponent<MovableObject>().getTouchStatus())
        {
            other.gameObject.transform.Translate(Vector3.right *(Time.deltaTime * speed));
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.tag + " has ENTERED the " + name);
        objectsInBucket.Add(other);
    }
 
    void OnTriggerExit2D(Collider2D other)
    {
        objectsInBucket.Remove(other);
    }
}
