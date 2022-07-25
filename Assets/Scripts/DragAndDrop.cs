using System;
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
        if (Input.touchCount > 0) {
            Touch t = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                
                    if (objCollider == touchCollider) {
                        Debug.Log("TOUCHING AN OBJECT: " + this.GameObject().name);
                        fingerDown = true;
                    }

                    break;
                
                case TouchPhase.Ended:
                    fingerDown = false;
                    break;
                
                case TouchPhase.Moved:
                    if (fingerDown) {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                    break;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (fingerDown == false && this.gameObject.CompareTag("Red Circle"))
        {
            other.GetComponent<ObjectBucket>().addScore();
            Debug.Log("XXXXXX " + other.GetComponent<ObjectBucket>().getScore());
            Destroy(this.gameObject);
        }
    }
}
