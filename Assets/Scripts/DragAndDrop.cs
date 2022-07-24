using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;
    
    // https://www.youtube.com/watch?v=FPJEbf2Fv1o&ab_channel=JasonFlack
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);

            if (t.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                
                if (col == touchedCollider)
                {
                    Debug.Log("TOUCHING AN OBJECT: " + this.GameObject().name);
                    moveAllowed = true;
                }
                else
                {
                    Debug.Log("NOT TOUCHING AN OBJECT: " + this.GameObject().name);
                }
            }
            
            else if (t.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
            
            else if (t.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

             
        }
    }
}
