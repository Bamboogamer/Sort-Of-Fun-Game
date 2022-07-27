using System.Collections.Generic;
using System.Drawing;
using TMPro;
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
        for (int i = objectsInBucket.Count-1; i >= 0; i--)
        {
            var col = objectsInBucket[i];
            Debug.Log(col.tag + " is IN the " + name);
            if (!col.GetComponentInParent<MultiTouchDrag>().touchStatus[col] && CompareTag(col.tag))
            {
                addScore();
                TMPtext.SetText("SCORE: " + getScore());
                Destroy(col.gameObject);
                objectsInBucket.Remove(col);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.tag + " has EXITED the " + name);
        objectsInBucket.Remove(other);
    }
}
