using UnityEngine;

public class MovableObject : MonoBehaviour
{
    // TODO: Can be used to denote categories this OBJECT is sorted in
    // Should make it easier and more flexible to use than the Tags feature.
    private bool touchStatus;

    void Start()
    {
        touchStatus = false;
    }
    
    public bool getTouchStatus()
    {
        return touchStatus;
    }

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

    // public void toggleTouchStatus()
    // {
    //     touchStatus = !touchStatus;
    // }
}
