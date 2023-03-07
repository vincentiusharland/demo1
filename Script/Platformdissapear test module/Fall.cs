using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(TimeToWait());
                }
    }
     IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds (1f);
        Destroy (this.gameObject);
    }
}
