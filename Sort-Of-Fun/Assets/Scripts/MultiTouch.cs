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
                MovableObject movableObjectScript = obj.GetComponent<MovableObject>();
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        // Debug.Log("TOUCH HAS BEGAN - " + obj.name);
                        movableObjectScript.touchOn();
                        movableObjectScript.setFingerId(t.fingerId);
                        break;
    
                    case TouchPhase.Ended:
                        // Debug.Log("TOUCH HAS ENDED - " + obj.name);
                        movableObjectScript.touchOff();
                        break;
    
                    case TouchPhase.Moved:
                        // Debug.Log("TOUCH HAS MOVED! " + obj.name);
                        if (movableObjectScript.getTouchStatus() &&
                            movableObjectScript.getFingerId() == t.fingerId)
                        {
                            objTouchCol.edgeRadius = 2.5f;
                            obj.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                        }
                        break;
    
                    case TouchPhase.Canceled:
                        // Debug.Log("TOUCH HAS CANCELLED - " + obj.name);
                        movableObjectScript.touchOff();
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