using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialo_option_enabler : MonoBehaviour
{
    // smp2

    public List<Transform> points;
    public int goalPoint = 0;
    [Header("smp2 mode")]
    public bool smp2special;
    public GameObject target_fl;
    public GameObject target_tr;
    [Header("elevator_2 mode")]
    public bool elevator_2;
    public GameObject target_tr_1;
    public GameObject target_tr_2;
    [Header("Eagle mode")]
    public bool eagle;
    public GameObject target_fl_1;
    public GameObject target_tr_3;
    [Header("Eagle mode")]
    public bool stage_4;
    public GameObject true_1;
    public GameObject true_2;
    public GameObject script_fl;
    [Header("Other Settings")]
    public float return_distance_2;
    public Transform child;
    public bool deattach;


    private void Update()
    {
        if (smp2special)
        {
            if (deattach == true)
            {
                child.parent = null;

            }
            Transform gp = points[goalPoint];
            if (Vector2.Distance(transform.position, gp.position) < return_distance_2 + 0.1f)
            {
                deattach = true;

            }
            if (Vector2.Distance(transform.position, gp.position) < return_distance_2)
            {
                Vector3 originposition = gameObject.transform.position;
                gameObject.SetActive(false);
                target_fl.SetActive(true);
                gameObject.transform.position = originposition;
                target_tr.SetActive(false);

            }

        }
        if (elevator_2)
        {

            Transform gp = points[goalPoint];

            if (Vector2.Distance(transform.position, gp.position) < return_distance_2)
            {
                target_tr_2.SetActive(true);
                gameObject.GetComponent<specialo_option_enabler>().enabled = false;
            }

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (smp2special)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Transform gp = points[goalPoint];
                target_fl.SetActive(false);
                target_tr.SetActive(true);

            }
        
        }
        if (elevator_2)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("collide");
                Transform gp = points[goalPoint];

                target_tr_1.SetActive(true);

            }
        }
        if (eagle)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("collide");
                Transform gp = points[goalPoint];

                target_fl_1.SetActive(false);
                target_tr_3.SetActive(true);
            }
        }
        if (stage_4)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("collide");
                Transform gp = points[goalPoint];

                true_1.SetActive(true);
                true_2.SetActive(true);
                script_fl.GetComponent<specialo_option_enabler>().stage_4=false;
            }
        }

    }
}
