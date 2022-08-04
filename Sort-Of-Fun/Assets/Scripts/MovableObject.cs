using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    [SerializeField] public List<string> categories;
    
    private bool touchStatus;
    // private bool safeStatus;
    private int fingerId;
    
    public BoxCollider2D touchCol;
    public Collider2D objCol; 

    void Start()
    {
        fingerId = -1;
        touchCol = GetComponents<BoxCollider2D>()[0];
        objCol = GetComponents<Collider2D>()[1];
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
        touchCol.edgeRadius = 0f;
    }
}
