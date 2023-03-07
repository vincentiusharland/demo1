using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemAdvance : MonoBehaviour
{
    //Collider Trigger
    public enum InteractionType { NONE, PickUp, Examine, GrabDrop }
    public InteractionType type;
    public float cooldownTime = 2;
    private float nextFireTime = 0;
    [Header("Examine")]
    public string descriptionText;
    public Sprite image;
    //for event
    public UnityEvent customEvent;
    //Interaction Type
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 3;
    }
    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                //Add the object to the Picked up item list 
                FindObjectOfType<InteractionAdvance>().PickedUpItem(gameObject);
                //Delete the object 
                //Destroy(gameObject);
                //Disable
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                //call the examine in interaction advance script
                FindObjectOfType<InteractionAdvance>().ExamineItem(this);
                Debug.Log("EXAMINE");
                break;
            case InteractionType.GrabDrop:
                //Grab interaction
                FindObjectOfType<InteractionAdvance>().GrabDrop();
                
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
        if (Time.time > nextFireTime)
        {
                customEvent.Invoke();
            nextFireTime = Time.time + cooldownTime;
        }
        ;
    }
}
