using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("Select the methode")]
    public bool mode_1;
    public bool mode_2;
    public bool mode_3;
    [Header("mode_1(0.5s)")]
    [SerializeField]
    GameObject platformPrefab;
    [Header("mode_2(0s)")]
    [SerializeField]
    GameObject platformPrefab2;
    [Header("mode_3")]
    [SerializeField]
    GameObject platformPrefab3;
    // Start is called before the first frame update
    public static PlatformManager Instance = null;
   
    
    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void Start()
    {
        if (mode_1) //0.5s
        {
            Instantiate(platformPrefab, new Vector2(1.35f, -21f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(4.05f, -19.5f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(1.35f, -17.5f), platformPrefab.transform.rotation);
        }
        if (mode_2) //0s
        {
            Instantiate(platformPrefab2, new Vector2(7.25f, -17.5f), platformPrefab2.transform.rotation);
            Instantiate(platformPrefab2, new Vector2(7.25f, -13.5f), platformPrefab2.transform.rotation);
        }
       if (mode_3)
        {
            Instantiate(platformPrefab3, new Vector2(-1f, 0f), platformPrefab3.transform.rotation);
        }

    }
    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
     
            yield return new WaitForSeconds(2f);
            Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
        }
    IEnumerator SpawnPlatform2(Vector2 spawnPosition)
    {
            yield return new WaitForSeconds(2f);
            Instantiate(platformPrefab2, spawnPosition, platformPrefab2.transform.rotation);
        }
    IEnumerator SpawnPlatform3(Vector2 spawnPosition)
    {
            yield return new WaitForSeconds(2f);
            Instantiate(platformPrefab3, spawnPosition, platformPrefab3.transform.rotation);
        }
    
}
