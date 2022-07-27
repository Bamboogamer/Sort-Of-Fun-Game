using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    List<Collider2D> objectsOnConveyor;
    Collider2D conveyorCollider;
    
    void Start()
    {
        speed = 2;
        conveyorCollider = GetComponent<Collider2D>();
        // GameObject movableObjects = transform.parent.gameObject.transform.GetChild(2).gameObject;
        // foreach (var obj in movableObjects.GetComponentsInChildren<Collider2D>())
        // {
        //     objectsOnConveyor.Add(obj);
        // }
        // Debug.Log("SIZE: " + objectsOnConveyor.Count);
    }

    void Update()
    {
        // Debug.Log("SIZE: " + objectsOnConveyor.Count);
        // foreach (Collider2D obj in objectsOnConveyor)
        // {
        //     Debug.Log(obj.name);
        //     if (obj.GetComponent<GameObject>().transform.position.x >= 10.62)
        //     {
        //         Destroy(obj.GetComponent<GameObject>());
        //     }
        //     else
        //     {
        //         obj.GetComponent<GameObject>().transform.Translate(Vector3.right * (Time.deltaTime * speed));
        //     }     
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        objectsOnConveyor.Add(other);
        Debug.Log("SIZE: " + objectsOnConveyor.Count);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        objectsOnConveyor.Remove(other);
    }
}
