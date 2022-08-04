using UnityEngine;

public class KillBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the collider is NOT the object collider, do not trigger
        if (other != other.GetComponent<MovableObject>().objCol) return;
        Destroy(other.gameObject);
    }
}