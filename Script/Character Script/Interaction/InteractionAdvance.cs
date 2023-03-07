using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionAdvance : MonoBehaviour
{
    [Header("Detection Parameters")]
    //detection point
    public Transform detectionPoint;
    //detection Radius
    public const float detectionRadius = 0.5f;
    //detection Layer
    public LayerMask detectionLayer;
    //cached Trigger Object
    public GameObject detectedObject;
    [Header("Examine Fields")]
    //examine windows object
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
    public bool isExamining;
    [Header ("Others")]
    //List of Picked Items
    public List<GameObject> pickedItems= new List<GameObject>();
    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;
    public bool isGrabbing;
    SpriteRenderer sr;
    Vector3 holderOffset;
    Vector3 grabDetectOffset;

    void Start()
    {
        sr = transform.parent.root.GetComponent<SpriteRenderer>();
        Vector3 root = transform.parent.root.transform.position;
        holderOffset = grabPoint.position - root;
        grabDetectOffset = detectionPoint.position - root;
    }
    bool DetectObject()
    {
        Collider2D obj = (Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer));
        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
        
    }
    void Update()
    {
        Vector3 root = transform.parent.root.transform.position;

        Vector2 dir = Vector2.right;
        grabPoint.position = root + holderOffset;
        detectionPoint.position = root + grabDetectOffset;

        if (sr.flipX == true) // right
        {
            dir = -Vector2.right;
            grabPoint.position = root - holderOffset;
            detectionPoint.position = root - grabDetectOffset;
        }
        if (DetectObject())
        {
            if (InteractInput())
            {
                //if we are grabbing something dont interact
                if (isGrabbing)
                {
                    GrabDrop();
                    return;
                }

                detectedObject.GetComponent<ItemAdvance>().Interact();
            }
        }
    }
    bool InteractInput()
    {

        return (Input.GetKeyDown(KeyCode.E));
    }
    private void onDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
    public void PickedUpItem(GameObject interactable)
    {
        pickedItems.Add(interactable);
    }
    public void GrabDrop()
    {
        //Check if we have a grabbed object, drop it
        if (isGrabbing)
        {
            //makeisgrabbing false
            isGrabbing = false;
            //unparent the grabbed object 
            grabbedObject.transform.parent = null;
            //set y position to its origin
            //grabbedObject.transform.position =
                 // new Vector3(grabbedObject.transform.position.x, grabbedObject.transform.position.y, grabbedObject.transform.position.z);
                 //new Vector3(grabbedObject.transform.position.x, grabbedObject.transform.position.y, grabbedObject.transform.position.z);
            //undo the kinematic
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.GetComponent<Collider2D>().isTrigger = false;
            //null the grabed object reference
            grabbedObject = null;
            
        }
        // Check if we have nothing grabbed, grab the detected item
        else
        {
            //enable the isgrabbing boolian
            isGrabbing = true;
            //assign the grabbed object to the object itself 
            grabbedObject = detectedObject;
            //parent the grabbed object to the player
            grabbedObject.transform.parent = grabPoint;
            //cahced the y value of the object
           //grabbedObjectYValue = grabbedObject.transform.position.y;
            //Adjust the position of the grabbed object closer to hand
            grabbedObject.transform.localPosition = grabPoint.localPosition;
            //make the object kinematic
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbedObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
    public void ExamineItem(ItemAdvance item)
    {
        if (isExamining)
        {
            examineWindow.SetActive(false);
            //enable the bool
            isExamining = false;
        }
        else
        {
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            examineText.text = item.descriptionText;
            examineWindow.SetActive(true);
            //enable the bool
            isExamining = true;
        }
       
    }
}
