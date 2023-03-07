using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooldown : MonoBehaviour
{
    public float cooldownTime =2;
    private float nextFireTime = 0;
    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButton(0))
                print("ability used,cooldown started");
            nextFireTime = Time.time + cooldownTime;
        }
    }
}
