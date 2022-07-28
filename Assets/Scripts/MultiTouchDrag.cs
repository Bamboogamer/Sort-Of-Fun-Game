using System;
using System.Collections.Generic;
using System.Linq;
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
        // TODO: Can be optimized using multi-threading
        foreach (Touch t in Input.touches)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
            Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);

            foreach (Collider2D objCollider in objColliders.Where(objCollider => objCollider == touchCollider))
            {
                BoxCollider2D boxCollider = objCollider as BoxCollider2D;
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log("TOUCHING AN OBJECT: " + objCollider.name);
                        touchStatus[objCollider] = true;
                        boxCollider.edgeRadius = 2;
                        break;

                    case TouchPhase.Ended:
                        Debug.Log("TOUCH HAS ENDED!");
                        boxCollider.edgeRadius = 0;
                        touchStatus[objCollider] = false;
                        break;

                    case TouchPhase.Moved:
                        if (touchStatus[objCollider])
                        {
                            objCollider.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                        }

                        break;

                    case TouchPhase.Canceled:
                        // Debug.Log("TOUCH HAS CANCELLED!");
                        break;

                    case TouchPhase.Stationary:
                        // Debug.Log("TOUCH IS STATIONARY!");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
    
    // Private Functions //
    private List<Collider2D> findColliders()
    {
         List<Collider2D> result = new List<Collider2D>();
         foreach (Touch t in Input.touches)
         {
             Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
             Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
 
             foreach (Collider2D objCollider in objColliders.Where(objCollider => objCollider == touchCollider))
             {
                 BoxCollider2D boxCollider = objCollider as BoxCollider2D;
                 result.Add(boxCollider);
                 break;
             }
         }
 
         return result;
    }
}
