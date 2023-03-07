using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    //public bool drops;
    public bool special;
    public bool special2;
    public bool special3;
    [Header("Special")]
    public GameObject theObject_true;
    public GameObject theObject2_false;
    [Header("Special_2")]
    public GameObject theObject3_true;
    [Header("Special_3")]
    public GameObject theObject4_false;
    public GameObject theObject5_false;
   // public GameObject theDrops;
    //public Transform dropPoint;
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Spike"))
        {
            
            //if (drops) 
                //Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
            if (special)
            {
                theObject_true.SetActive(true);
                theObject2_false.SetActive(false);
            }
            if (special2)
            {
                theObject3_true.SetActive(true);
            }
            if (special3)
            {
                theObject4_false.SetActive(false);
                theObject5_false.SetActive(false); ;
            }
            gameObject.SetActive(false);
        }
        }
}

