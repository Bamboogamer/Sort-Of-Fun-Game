using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectBucket : MonoBehaviour
{
    List<Collider2D> objectsInBucket;
    int score;
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
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        objectsInBucket.Add(other);
        Debug.Log(other.tag + " has ENTERED the " + name);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        foreach(Collider2D col in objectsInBucket)
        {
            Debug.Log(col.tag + " is IN the " + name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.tag + " has EXITED the " + name);
        objectsInBucket.Remove(other);
    }
}
