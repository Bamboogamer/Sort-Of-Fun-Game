using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DragAndDrop : MonoBehaviour
{
    bool fingerDown;
    Collider2D objCollider;
    
    // MULTI TOUCH: https://www.youtube.com/watch?v=FPJEbf2Fv1o&ab_channel=JasonFlack
    void Start()
    {
        objCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch t = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                    
                    if (objCollider == touchCollider) 
                    {
                        Debug.Log("TOUCHING AN OBJECT: " + gameObject.name);
                        fingerDown = true;
                    }
                    break;
                
                case TouchPhase.Ended:
                    fingerDown = false;
                    break;
                
                case TouchPhase.Moved:
                    if (fingerDown) 
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                    break;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // String thisTag = gameObject.tag;
        // String otherTag = other.tag;
        //
        // Debug.Log("THIS TAG: " + thisTag);
        // Debug.Log("OTHER TAG: " + otherTag);
        
        if (fingerDown == false && gameObject.CompareTag(other.tag))
        {
            other.GetComponent<ObjectBucket>().addScore();
            other.GetComponent<ObjectBucket>().TMPtext.SetText("SCORE: " + other.GetComponent<ObjectBucket>().getScore());
            Destroy(gameObject);
        }
    }
}
