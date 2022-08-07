using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    [SerializeField] public List<string> categories;
    
    private bool touchStatus;
    // private bool safeStatus;
    private int fingerId;
    
    public Collider2D objCol; 
    public CircleCollider2D touchCol;
    
    void Start()
    {
        fingerId = -1;
        touchStatus = false;
        // safeStatus = true;
    }

    public int getFingerId()
    {
        return fingerId;
    }

    public void setFingerId(int i)
    {
        fingerId = i;
    }

    public bool getTouchStatus()
    {
        return touchStatus;
    }
    
    // public bool getSafeStatus()
    // {
    //     return safeStatus;
    // }
    //
    // public void safeOn()
    // {
    //     safeStatus = true;
    // }
    //
    // public void safeOff()
    // {
    //     safeStatus = false;
    // }
    

    public void touchOn()
    {
        Debug.Log("Player is touching: " + name);
        touchStatus = true;
    }

    public void touchOff()
    {
        Debug.Log("Player has let go of: " + name);
        touchStatus = false;
        fingerId = -1;
        touchCol.radius = 0f;
    }
}
