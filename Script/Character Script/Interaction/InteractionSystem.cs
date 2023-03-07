using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    //detection point
    public Transform detectionPoint;
    //detection Radius
    private const float detectionRadius= 0.2f;
    //detection Layer
    public LayerMask detectionLayer;
  
  
   bool DetectObject()
    {
        return(Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer));
    }
    void Update()
    {
        if(DetectObject())
        {
            if (InteractInput())
            {
                Debug.Log("INTERACT");
            }
        }
    }
    bool InteractInput()
    {
        return (Input.GetKeyDown(KeyCode.E));
    }
}
