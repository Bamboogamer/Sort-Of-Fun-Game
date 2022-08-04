using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectBucket : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] List<string> categories;
    
    private List<Collider2D> objectsInBucket;
    
    public TextMeshProUGUI TMPtext;
    
    void Start()
    {
        score = 0;
        objectsInBucket = new List<Collider2D>();
        TMPtext = GetComponentInChildren<TextMeshProUGUI>();
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
        // If the collider is NOT the object collider, do not trigger
        if (other == other.GetComponent<MovableObject>().touchCol) return;
        
        // Finds intersections between both lists, true if any element match
        bool intersectLists = categories.Intersect(other.GetComponent<MovableObject>().categories).Any();
        var fingerDown = other.gameObject.GetComponent<MovableObject>().getTouchStatus();
        
        // If finger is still down OR the tag does not match
        // TODO: Possibly add a "punishment" if you put the wrong object in the bucket
        if (fingerDown || !intersectLists) return;
        
        score++;
        TMPtext.SetText("SCORE: " + score);
        objectsInBucket.Remove(other.GetComponent<MovableObject>().objCol);
        Destroy(other.gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name + " has ENTERED the " + name);
        // If the collider is NOT the object collider, do not trigger
        if (other == other.GetComponent<MovableObject>().touchCol) return;
        objectsInBucket.Add(other);
    }
 
    void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log(other.name + " has EXITED the " + name);
        objectsInBucket.Remove(other);
    }
}
