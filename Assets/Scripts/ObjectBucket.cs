using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectBucket : MonoBehaviour
{
    [SerializeField] int score; // Will increase based on difficulty
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
        
        // If finger is still down OR the tag does not match
        // TODO: Possibly add a "punishment" if you put the wrong object in the bucket
        if (fingerDown || !CompareTag(other.tag)) return;
        
        BoxCollider2D boxCol = other as BoxCollider2D;
        boxCol.edgeRadius = 0;
        
        score++;
        TMPtext.SetText("SCORE: " + score);
        objectsInBucket.Remove(other);
        Destroy(other.gameObject);
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
        boxCol.edgeRadius = 0.35f; // TODO: Could be changed to be based more on distance than instantly changing this
        // Debug.Log(other.tag + " has EXITED the " + name);
        objectsInBucket.Remove(other);
    }
}
