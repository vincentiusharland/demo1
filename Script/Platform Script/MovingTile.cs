using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    int idChangeValue = 1;
    public List<Transform> points;
    public Transform Tile;
    public int goalPoint = 0;
    public float moveSpeed = 2;
    [Header("2Waymode")]
    public bool way2_mode;
    public float return_distance;
    [Header("eagle")]
    public bool eagle;
    
    

    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint();
    }
    void MoveToNextPoint()
    {
        Transform gp = points[goalPoint];

        //move enemy towards point
        Tile.position = Vector2.MoveTowards(Tile.position, gp.position, Time.deltaTime * moveSpeed);
        if (way2_mode)
        {
            Tile.position = Vector2.MoveTowards(Tile.position, gp.position, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, gp.position) < return_distance)
        {
        if (goalPoint == points.Count - 1)
        idChangeValue = -1;
         if (goalPoint == 0)
          idChangeValue = 1;
            goalPoint += idChangeValue;
            }
        }
        if (eagle)
        {
            if (Vector2.Distance(transform.position, gp.position) < return_distance)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
