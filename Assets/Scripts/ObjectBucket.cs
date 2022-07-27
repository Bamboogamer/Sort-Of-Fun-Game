using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectBucket : MonoBehaviour
{
    List<Collider2D> objectsInBucket;
    int score;
    TextMeshProUGUI TMPtext;
    
    void Start()
    {
        score = 0;
        objectsInBucket = new List<Collider2D>();
    }

    private void Update()
    {
        foreach (Collider2D col in objectsInBucket)
        {
            OnTriggerStay2D(col);
        }  
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag + " is IN the " + name);

        // If finger is still down OR the tag does not match
        // TODO: Possibly add a "punishment" if you put the wrong object in the bucket
        if (other.GetComponentInParent<MultiTouchDrag>().touchStatus[other] || !CompareTag(other.tag)) return;
        
        score++;
        TMPtext.SetText("SCORE: " + score);
        Destroy(other.gameObject);
        objectsInBucket.Remove(other);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        objectsInBucket.Add(other);
        Debug.Log(other.tag + " has ENTERED the " + name);
    }
 
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.tag + " has EXITED the " + name);
        objectsInBucket.Remove(other);
    }
}
