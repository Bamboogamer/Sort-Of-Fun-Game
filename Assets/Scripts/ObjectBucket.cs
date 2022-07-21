using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// TODO: https://www.youtube.com/watch?v=yL62XU8WGIQ&ab_channel=Antarsoft

public class ObjectBucket : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object ENTERED the Trigger");
        Debug.Log(other.name);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Object is IN the Trigger");
        Debug.Log(other.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Object has EXITED the Trigger");
        Debug.Log(other.name);
    }
}