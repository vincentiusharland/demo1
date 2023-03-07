using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Teleport : MonoBehaviour
{
    [Header("Special(usingevent)")]
    public bool special;
    public GameObject theObject;
    public Transform dropPoint;
    [Header("Special_2(usingcollider)")]
    public bool special2;
    public GameObject theObject2;
    public Transform dropPoint2;
    [Header("for fun reset")]
    public bool special3;
    public GameObject theObject3;
    public Transform dropPoint3;
    // Start is called before the first frame update
    public void Start()
    {
        if (special)
        {
            theObject.transform.position = new Vector3(dropPoint.position.x, dropPoint.position.y,0);
        }
        if (special3)
        {
            theObject3.transform.position = new Vector3(dropPoint3.position.x, dropPoint3.position.y, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (special2)
            {
                theObject2.transform.position = new Vector3(dropPoint2.position.x, dropPoint2.position.y, 0);
            }
    }
}



