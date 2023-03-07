using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public static hit_interaction Instance = null;
    [SerializeField]
    GameObject ammunition;

    public bool crank_ammunition;
    public bool crank_movingspike1;
    public bool crank_final_1;
    public bool crank_final_2;
    public bool crank_final_3;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void Start()
    {
        if (crank_ammunition)
        {
            Instantiate(ammunition, new Vector2(4f, 13f), ammunition.transform.rotation);
        }
        if (crank_movingspike1)
        { 
            Instantiate(ammunition, new Vector2(-10.7f, -0.37f), ammunition.transform.rotation); 
        }     
        if (crank_final_1)
        {
            Instantiate(ammunition, new Vector2(14f, -18.25f), ammunition.transform.rotation);
        }
        if (crank_final_2)
        {
            Instantiate(ammunition, new Vector2(19f, -18.25f), ammunition.transform.rotation);
        }
        if (crank_final_3)
        {
            Instantiate(ammunition, new Vector2(26f, -18.25f), ammunition.transform.rotation);
        }
    }
    //IEnumerator SpawnBullet(Vector2 spawnPosition)
    //{
        //yield return new WaitForSeconds(2f);
       // Instantiate( ammunition , spawnPosition, ammunition .transform.rotation);
    //}
}
