using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManagerScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlatformManagerScript2 Instance = null;
    [SerializeField]
    GameObject platformPrefab;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        Instantiate(platformPrefab, new Vector2(0f, 0f), platformPrefab.transform.rotation);

    }
    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
