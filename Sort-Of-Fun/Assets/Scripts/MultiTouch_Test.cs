using System;
using System.Linq;
using UnityEngine;

public class MultiTouch_Test : MonoBehaviour
{
    private Camera cam;
    
    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Debug.Log("TOUCH COUNT: " + Input.touchCount);
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch t;
            Vector2 touchPosition;
            RaycastHit2D[] hitInfo;
            GameObject obj;
            CircleCollider2D objTouchCol;
            
            // https://answers.unity.com/questions/1751277/how-can-i-find-all-colliders-that-overlap-at-a-poi.html
            // https://docs.unity3d.com/ScriptReference/Collision2D.html
            // May need to change back to a touch collider for the finger rather than use RayCast
            try
            {
                t = Input.GetTouch(i);
                touchPosition = cam.ScreenToWorldPoint(t.position);
                
                hitInfo = Physics2D.RaycastAll(cam.ScreenToWorldPoint(t.position), Vector2.zero);
                if (i == 1)
                {
                    foreach (RaycastHit2D rc in hitInfo)
                    {
                        Debug.Log(rc.collider.name + " LOOK HERE IDIOT");
                    }
                    
                }
                
                
                // foreach (RaycastHit rc in hitInfo)
                // {
                //     obj = rc.transform.gameObject;
                //     objTouchCol = obj.GetComponent<MovableObject>().touchCol;
                //     MovableObject movableObjectScript = obj.GetComponent<MovableObject>();
                //     
                //     switch (t.phase) 
                //     {
                //         case TouchPhase.Began: // Debug.Log("TOUCH HAS BEGAN - " + obj.name);
                //             movableObjectScript.touchOn();
                //             movableObjectScript.setFingerId(t.fingerId);
                //             break;
                //
                //         case TouchPhase.Ended:
                //         // Debug.Log("TOUCH HAS ENDED - " + obj.name);
                //             movableObjectScript.touchOff();
                //             break;
                //
                //         case TouchPhase.Moved:
                //             // Debug.Log("TOUCH HAS MOVED! " + obj.name);
                //             if (movableObjectScript.getTouchStatus() && movableObjectScript.getFingerId() == t.fingerId)
                //             {
                //                 objTouchCol.radius = 2.5f;
                //                 obj.transform.position = new Vector3(touchPosition.x, touchPosition.y, -5);
                //             }
                //             break;
                //
                //         case TouchPhase.Canceled:
                //              
                //             // Debug.Log("TOUCH HAS CANCELLED - " + obj.name);
                //             movableObjectScript.touchOff();
                //             break;
                //
                //         case TouchPhase.Stationary:
                //             // Debug.Log("TOUCH IS STATIONARY - " + obj.name);
                //             break;
                //
                //         default:
                //             throw new ArgumentOutOfRangeException();
                //     }
                // }
            }
            catch (Exception e){ return; }
        }
    }
}