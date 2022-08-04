using System;
using UnityEngine;

public class MultiTouch : MonoBehaviour
{
    private Camera cam;
    
    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPosition = cam.ScreenToWorldPoint(t.position);
            RaycastHit2D hitInfo = Physics2D.Raycast(cam.ScreenToWorldPoint(t.position), Vector2.zero);
            GameObject obj = hitInfo.transform.gameObject;

            if (!obj.CompareTag("MovableObject"))
            {
                Debug.Log("NOT TOUCHING MovableObject");
                Destroy(obj);
            }
            
            // If the raycast is touching something and that something is a "MovableObject"
            if (hitInfo && obj.CompareTag("MovableObject"))
            {
                BoxCollider2D objTouchCol= obj.GetComponent<MovableObject>().touchCol;
                
                // Debug.Log(obj.name);
                
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        // Debug.Log("TOUCH HAS BEGAN - " + obj.name);
                        obj.GetComponent<MovableObject>().touchOn();
                        objTouchCol.edgeRadius = 2.5f;
                        break;
    
                    case TouchPhase.Ended:
                        // Debug.Log("TOUCH HAS ENDED - " + obj.name);
                        obj.GetComponent<MovableObject>().touchOff();
                        objTouchCol.edgeRadius = 0f;
                        break;
    
                    case TouchPhase.Moved:
                        // Debug.Log("TOUCH HAS MOVED! " + obj.name);
                        obj.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                        break;
    
                    case TouchPhase.Canceled:
                        // Debug.Log("TOUCH HAS CANCELLED - " + obj.name);
                        obj.GetComponent<MovableObject>().touchOff();
                        break;
    
                    case TouchPhase.Stationary:
                        // Debug.Log("TOUCH IS STATIONARY - " + obj.name);
                        break;
    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}