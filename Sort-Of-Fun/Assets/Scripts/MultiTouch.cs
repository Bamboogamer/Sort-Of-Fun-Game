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
            Touch t;
            Vector2 touchPosition;
            RaycastHit2D hitInfo;
            GameObject obj;
            BoxCollider2D objTouchCol;
            
            try
            {            
                t = Input.GetTouch(i);
                touchPosition = cam.ScreenToWorldPoint(t.position);
                hitInfo = Physics2D.Raycast(cam.ScreenToWorldPoint(t.position), Vector2.zero);
                obj = hitInfo.transform.gameObject;
                objTouchCol = obj.GetComponent<MovableObject>().touchCol;
            }
            catch (Exception e){ return; }
            
            // If the raycast is touching something and that something is a "MovableObject"
            if (hitInfo)
            {
                // TODO: Maybe check the RayCast and ONLY select the FIRST Collider and ignore any others that enter the initial collider's area.
                // TODO: In other words, FORCE a 1-to-1 relationship with touch raycast and object touch collider
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        // Debug.Log("TOUCH HAS BEGAN - " + obj.name);
                        obj.GetComponent<MovableObject>().touchOn();
                        break;
    
                    case TouchPhase.Ended:
                        // Debug.Log("TOUCH HAS ENDED - " + obj.name);
                        obj.GetComponent<MovableObject>().touchOff();
                        objTouchCol.edgeRadius = 0f;
                        break;
    
                    case TouchPhase.Moved:
                        // Debug.Log("TOUCH HAS MOVED! " + obj.name);
                        if (obj.GetComponent<MovableObject>().getTouchStatus())
                        {
                            objTouchCol.edgeRadius = 2.5f;
                            obj.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                        }
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