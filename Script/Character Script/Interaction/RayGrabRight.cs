using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGrabRight : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    SpriteRenderer sr;
    Vector3 holderOffset;
    Vector3 grabDetectOffset;

    void Start()
    {
        sr = transform.parent.root.GetComponent<SpriteRenderer>();
        Vector3 root = transform.parent.root.transform.position;
        holderOffset = boxHolder.position - root;
        grabDetectOffset = grabDetect.position - root;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 root = transform.parent.root.transform.position;
       
        Vector2 dir = Vector2.right;
        boxHolder.position = root + holderOffset;
        grabDetect.position = root + grabDetectOffset;

        if (sr.flipX==true) // right
        {
            dir = -Vector2.right;
            boxHolder.position = root - holderOffset;
            grabDetect.position = root - grabDetectOffset;
        }

        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, dir * transform.localScale, rayDist);
        if (grabCheck.collider != null && grabCheck.collider.tag == "interactable")
        {
            if (Input.GetKey(KeyCode.G))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
