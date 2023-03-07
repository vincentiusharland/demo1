using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public List<Transform> points;
    public Transform enemy;
    public int goalPoint = 0;
    public float moveSpeed = 2;
    int idChangeValue = 1;

    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint(); 
    }
    void MoveToNextPoint()
    {
        Transform gp = points[goalPoint];
        if (gp.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        //move enemy towards point
       transform.position = Vector2.MoveTowards(transform.position, gp.position, Time.deltaTime * moveSpeed);
        
        if(Vector2.Distance(transform.position,gp.position)<1f)
        {
            if (goalPoint == points.Count - 1)
                idChangeValue = -1;
            if (goalPoint==0)
                idChangeValue=1;
            goalPoint += idChangeValue;

        }
    }
}
