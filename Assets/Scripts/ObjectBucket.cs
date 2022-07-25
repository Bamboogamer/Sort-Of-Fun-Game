using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


// TODO: https://www.youtube.com/watch?v=yL62XU8WGIQ&ab_channel=Antarsoft

public class ObjectBucket : MonoBehaviour
{
    List<Collider2D> objectsInBucket;
    int score;
    [SerializeField] 
    public TextMeshProUGUI TMPtext;

    public int getScore()
    {
        return score;
    }

    public void addScore()
    {
        score++;
    }
    
    void Start()
    {
        score = 0;
        objectsInBucket = new List<Collider2D>();
        TMPtext = GetComponent<TextMeshProUGUI>();
        // Debug.Log("AAAAAAAAAAAAAAAAAa   "  +GetComponentInChildren<TextMeshPro>().name);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        objectsInBucket.Add(other);
        Debug.Log(other.tag + " has ENTERED the " + this.name);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        foreach(Collider2D col in objectsInBucket)
        {
            Debug.Log(col.tag + " is IN the " + this.name);
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.tag + " has EXITED the " + this.name);
        objectsInBucket.Remove(other);
    }
}
