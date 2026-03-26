using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformSpawner : MonoBehaviour
{
    public Vector3 spawnPosition = new Vector3(0, -0.3f, 0);
    public Vector3 beginningPlatformPosition = new Vector3(0, -0.3f, 0);
    public float spawnInterval = 1.5f;
    private float markedTime;

    // Platform prefabs
    public List<GameObject> platformTrapPrefabs;
    public GameObject basicPlatform;
    public GameObject blockTrapPlatform;
    public GameObject movingWallTrapPlatform;
    public GameObject axeSwingTrapPlatform;
    public GameObject spikeTrapPlatform;

    void Start()
    {
        // Add all trap platform prefabs to the array
        platformTrapPrefabs.Add(blockTrapPlatform);
        platformTrapPrefabs.Add(axeSwingTrapPlatform);
        platformTrapPrefabs.Add(movingWallTrapPlatform);
        platformTrapPrefabs.Add(spikeTrapPlatform);

        // Create stationary platform for view
        GameObject viewPlatform = SpawnPlatform(basicPlatform, spawnPosition);
        viewPlatform.GetComponent<PlatformMovement>().enabled = false;

        // Create first moving platform
        SpawnPlatform(basicPlatform, beginningPlatformPosition);
        markedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (currentTime - markedTime > spawnInterval)
        {
            SpawnPlatform(randomTrapPlatform(), spawnPosition);
            markedTime = Time.time; // Reset the timer
        }
    }

    private GameObject SpawnPlatform(GameObject platform, Vector3 position)
    {
        return Instantiate(platform, position, Quaternion.identity);
    }

    private GameObject randomTrapPlatform(){
        int randomIndex = Random.Range(0, platformTrapPrefabs.Count);
        return platformTrapPrefabs[randomIndex];
    }
}
