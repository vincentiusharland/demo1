using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissapearing_bullet : MonoBehaviour
{
  
    Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //hit_interaction.Instance.StartCoroutine("SpawnBullet", new Vector2(transform.position.x, transform.position.y));
        Invoke("DropAmmunition", 0f);
        
    }
  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;
      
        if (collision.GetComponent<ShootingAction>())
            collision.GetComponent<ShootingAction>().Action();
    }
    void DropAmmunition()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 1.2f);
    }

}
