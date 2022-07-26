using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MultiTouchDrag : MonoBehaviour
{
    public List<Collider2D> objColliders;
    public Dictionary<Collider2D, bool> touchStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("STARTED MULTITOUCH");
        objColliders = new List<Collider2D>(GetComponentsInChildren<Collider2D>());
        touchStatus = new Dictionary<Collider2D, bool>();
        //
        // var i = 0;
        foreach (Collider2D col in objColliders)
        {
            touchStatus[col] = false;
        }
    }

    // Update is called once per frame 
    void Update()
    {
        foreach (Touch t in Input.touches)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
            Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);

            foreach (Collider2D objCollider in objColliders)
            {
                Debug.Log("TEST" + objCollider.GetType());
                switch (t.phase)
                    {
                        case TouchPhase.Began:
                            if (objCollider == touchCollider)
                            {
                                Debug.Log("TOUCHING AN OBJECT: " + this.GameObject().name);
                                touchStatus[objCollider] = true;
                            }
                            break;
                        case TouchPhase.Ended:
                            touchStatus[objCollider] = false;
                            break;
                        case TouchPhase.Moved:
                            if (touchStatus[objCollider])
                            {
                                objCollider.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                            }
                            break;
                    }
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        foreach (Collider2D objCollider in objColliders)
        {
            var thisTag = objCollider.tag;
            var otherTag = other.tag;
            Debug.Log("THIS TAG: " + thisTag);
            Debug.Log("OTHER TAG: " + otherTag);
            if (touchStatus[objCollider] == false && objCollider.CompareTag(other.tag))
            {
                other.GetComponent<ObjectBucket>().addScore();
                other.GetComponent<ObjectBucket>().TMPtext.SetText("SCORE: " + other.GetComponent<ObjectBucket>().getScore());
                Destroy(gameObject);
            }
        }

        
    }
}
