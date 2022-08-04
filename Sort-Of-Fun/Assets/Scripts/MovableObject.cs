using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    [SerializeField] public List<string> categories;
    
    private bool touchStatus;
    // private bool safeStatus; // TODO: used to determine of the object should be deleted or not if its not in a safe zone
    public BoxCollider2D touchCol;
    public Collider2D objCol; 

    void Start()
    {
        touchCol = GetComponents<BoxCollider2D>()[0];
        objCol = GetComponents<Collider2D>()[1];
        touchStatus = false;
        // safeStatus = true;
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
    }
}
