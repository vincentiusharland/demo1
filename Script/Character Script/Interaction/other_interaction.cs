using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class other_interaction : MonoBehaviour
{
    public bool test_mode;
  
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        { 
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            gameObject.SetActive(false);
        }
        if(test_mode)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("Stage_3");
            }

            if (other.gameObject.CompareTag("Spike"))
            {
                SceneManager.LoadScene("Stage_3");
            }
        }
    }
}
