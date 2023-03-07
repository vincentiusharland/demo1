using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Itembasic : MonoBehaviour
{
//Collider Trigger
public enum InteractionType { NONE, PickUp,Examine}
    public InteractionType type;
//Interaction Type
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 3;
    }
    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PickUp:
                Debug.Log("PICK UP");
                break;
            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}