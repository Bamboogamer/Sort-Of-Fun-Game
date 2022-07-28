using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectBucket : MonoBehaviour
{
    [SerializeField] int score;
    public TextMeshProUGUI TMPtext;
    List<Collider2D> objectsInBucket;
    
    void Start()
    {
        score = 0;
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
        // Debug.Log(other.tag + " is IN the " + name);
        var fingerDown = other.GetComponentInParent<MultiTouchDrag>().touchStatus[other];
        BoxCollider2D boxCol = other as BoxCollider2D;
        boxCol.edgeRadius = 0;
        
        // If finger is still down OR the tag does not match
        // TODO: Possibly add a "punishment" if you put the wrong object in the bucket
        if (fingerDown || !CompareTag(other.tag)) return;
        
        score++;
        TMPtext.SetText("SCORE: " + score);
        Destroy(other.gameObject);
        objectsInBucket.Remove(other);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        BoxCollider2D boxCol = other as BoxCollider2D;
        boxCol.edgeRadius = 0;
        // Debug.Log(other.tag + " has ENTERED the " + name);
        objectsInBucket.Add(other);
        
    }
 
    void OnTriggerExit2D(Collider2D other)
    {
        BoxCollider2D boxCol = other as BoxCollider2D;
        boxCol.edgeRadius = 0.25f;
        // Debug.Log(other.tag + " has EXITED the " + name);
        objectsInBucket.Remove(other);
    }
}
