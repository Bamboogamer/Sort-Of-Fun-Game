using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MultiTouchDrag : MonoBehaviour
{
    public List<Collider2D> objColliders;
    public Dictionary<Collider2D, bool> touchStatus;
    
    void Start()
    {
        objColliders = new List<Collider2D>(GetComponentsInChildren<Collider2D>());
        touchStatus = new Dictionary<Collider2D, bool>();
        foreach (Collider2D col in objColliders)
        {
            touchStatus[col] = false;
        }
    }

    void Update()
    {
        Debug.Log("NUMBER OF TOUCHES: " + Input.touches.Length);
        foreach (Touch t in Input.touches)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
            Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);

            foreach (Collider2D objCollider in objColliders)
            {
                if (objCollider == touchCollider)
                {
                    // Debug.Log("TEST" + objCollider.GetType());
                    switch (t.phase)
                    {
                        case TouchPhase.Began:
                            Debug.Log("TOUCHING AN OBJECT: " + this.GameObject().name);
                            touchStatus[objCollider] = true;
                            break;
                        
                        case TouchPhase.Ended:
                        
                            Debug.Log("TOUCH HAS ENDED! -- DANNY");
                            touchStatus[objCollider] = false;
                            break;
                        
                        case TouchPhase.Moved:
                            if (touchStatus[objCollider])
                            {
                                objCollider.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                            }
                            break;
                        
                        case TouchPhase.Canceled:
                            Debug.Log("TOUCH HAS CANCELLED! -- DANNY");
                            break;
                        
                        case TouchPhase.Stationary:
                            Debug.Log("TOUCH HAS STATIONARY! -- DANNY");
                            break;
                        
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
    
    // void OnTriggerStay2D(Collider2D other)
    // {
    //     foreach (Collider2D objCollider in objColliders)
    //     {
    //         var thisTag = objCollider.tag;
    //         var otherTag = other.tag;
    //         Debug.Log("THIS TAG: " + thisTag);
    //         Debug.Log("OTHER TAG: " + otherTag);
    //         
    //         if (touchStatus[objCollider] == false && objCollider.CompareTag(other.tag))
    //         {
    //             other.GetComponent<ObjectBucket>().addScore();
    //             other.GetComponent<ObjectBucket>().TMPtext.SetText("SCORE: " + other.GetComponent<ObjectBucket>().getScore());
    //             Destroy(gameObject);
    //         }
    //     }
    // }
}
