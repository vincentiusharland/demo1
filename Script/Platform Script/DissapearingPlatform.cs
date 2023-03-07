using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingPlatform : MonoBehaviour
{
    [Header("mode1(0.5s)")]
    public bool mode_1;
    [SerializeField]
    float time1;
    [Header("mode2(0s)")]
    public bool mode_2;
    [SerializeField]
    float time2;
    [Header("mode3")]
    public bool mode_3;
    [SerializeField]
    float time3;
    [Header("modeTest(0.5s)")]
    public bool mode_Test;
    [SerializeField]
    float time_Test;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("GroundCollider"))
            if (mode_Test)
        {
            Destroy(gameObject, time_Test);
            PlatformManager.Instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            if (mode_1)
            {
                Destroy(gameObject, time1);
                PlatformManager.Instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
            }
            if (mode_2)
            {
                Destroy(gameObject, time2);
                PlatformManager.Instance.StartCoroutine("SpawnPlatform2", new Vector2(transform.position.x, transform.position.y));
            }
            if (mode_3)
            {
                Destroy(gameObject, time3);
                PlatformManager.Instance.StartCoroutine("SpawnPlatform3", new Vector2(transform.position.x, transform.position.y));
            }
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }

}
