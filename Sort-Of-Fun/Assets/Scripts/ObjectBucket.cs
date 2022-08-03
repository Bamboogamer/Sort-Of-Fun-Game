using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectBucket : MonoBehaviour
{
    public TextMeshProUGUI TMPtext;
    List<Collider2D> objectsInBucket;
    
    [SerializeField] int score;
    [SerializeField] public List<string> categories;
    
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
        // Finds intersections between both lists, true if any element match
        bool intersectLists = categories.Intersect(other.GetComponent<MovableObject>().categories).Any();
        // Debug.Log("TESTING: " + intersectLists);
        // Debug.Log(string.Join(",", categories.ToArray()));
        // Debug.Log(string.Join(",", string.Join(",", other.GetComponent<MovableObject>().categories.ToArray())));
        
        // Debug.Log(other.tag + " is IN the " + name);
        var fingerDown = other.gameObject.GetComponent<MovableObject>().getTouchStatus();
        
        // If finger is still down OR the tag does not match
        // TODO: Possibly add a "punishment" if you put the wrong object in the bucket
        if (fingerDown || !intersectLists) return;
        
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
        Debug.Log(other.name + " has ENTERED the " + name);
        objectsInBucket.Add(other);
        
    }
 
    void OnTriggerExit2D(Collider2D other)
    {
        BoxCollider2D boxCol = other as BoxCollider2D;
        boxCol.edgeRadius = 0.35f; // TODO: Could be changed to be based more on distance than instantly changing this
        Debug.Log(other.name + " has EXITED the " + name);
        objectsInBucket.Remove(other);
    }
}
