using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiTouchDrag : MonoBehaviour
{
    public List<Collider2D> objColliders;
    private Camera cam;
    
    void Awake()
    {
        cam = Camera.main;
    }
    
    void Start()
    {
        // objColliders = new List<Collider2D>(GetComponentsInChildren<Collider2D>());
    }
    
    // TODO: Could possibly add a second Collider to the object to distinguish TOUCH vs Point Trigger
    // TODO: Try to use Ray-casting instead of using a object list? --> https://forum.unity.com/threads/touching-a-2d-sprite.233483/
    void Update()
    {
        objColliders = new List<Collider2D>(GetComponentsInChildren<Collider2D>());
        // TODO: Can be optimized using multi-threading??
        foreach (Touch t in Input.touches)
        {
            Vector2 touchPosition = cam.ScreenToWorldPoint(t.position);
            Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);

            foreach (Collider2D objCollider in objColliders.Where(objCollider => objCollider == touchCollider))
            {
                // To allow to change of collider edges
                BoxCollider2D boxCollider = objCollider as BoxCollider2D;
                
                if (!objCollider.Equals(null))
                {
                    bool touchStatus = boxCollider.gameObject.GetComponent<MovableObject>().getTouchStatus();
                    switch (t.phase)
                    {
                        case TouchPhase.Began:
                            // Debug.Log("TOUCHING AN OBJECT: " + objCollider.name);
                            boxCollider.edgeRadius = 2;
                            boxCollider.gameObject.GetComponent<MovableObject>().touchOn();
                            break;
    
                        case TouchPhase.Ended:
                            // Debug.Log("TOUCH HAS ENDED FOR: " + objCollider.name);
                            boxCollider.edgeRadius = 0;
                            boxCollider.gameObject.GetComponent<MovableObject>().touchOff();
                            break;
    
                        case TouchPhase.Moved:
                            if (touchStatus)
                            {
                                objCollider.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                            }
                            break;
    
                        case TouchPhase.Canceled:
                            // Debug.Log("TOUCH HAS CANCELLED! " + objCollider.name);
                            break;
    
                        case TouchPhase.Stationary:
                            // Debug.Log("TOUCH IS STATIONARY! " + objCollider.name);
                            break;
    
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
    
    // // Private Functions //
    // // TODO: This was used for testing optimization, but ignore for now
    // private List<Collider2D> findColliders()
    // {
    //      List<Collider2D> result = new List<Collider2D>();
    //      foreach (Touch t in Input.touches)
    //      {
    //          Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
    //          Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
    //
    //          foreach (Collider2D objCollider in objColliders.Where(objCollider => objCollider == touchCollider))
    //          {
    //              BoxCollider2D boxCollider = objCollider as BoxCollider2D;
    //              result.Add(boxCollider);
    //              break;
    //          }
    //      }
    //
    //      return result;
    // }
}
