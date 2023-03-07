using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingcheck : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("movingplatform"))
            transform.parent = other.gameObject.transform;
        else

            transform.parent = null;
    }
}
       
    

