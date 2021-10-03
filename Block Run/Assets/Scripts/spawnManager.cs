using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float startDelay = 3;
    private float spawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacles", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomObstacles() {
        Vector3 spawnPos = new Vector3(Random.Range(22, 30), 0, 0);
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        if (FindObjectOfType<gameManager>().gameHasEnded == false)
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
