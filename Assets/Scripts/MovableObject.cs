using Unity.VisualScripting;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private bool touchStatus;

    void Start()
    {
        touchStatus = false;
    }
    
    public bool getTouchStatus()
    {
        return touchStatus;
    }

    public void toggleTouchStatus()
    {
        touchStatus = !touchStatus;
    }
}
