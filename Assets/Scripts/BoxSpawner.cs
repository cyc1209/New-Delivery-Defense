using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    float spawnTime;
    public float limitTime;
    public Transform spawnPoint;
    public GameObject box;
    float deltaSpawnTime;
    float playingTime = 0;
    public GameManager gameManager;
    void Start()
    {
        spawnTime = 2f + (1f / gameManager.level);
    }
    void Update()
    {
        if (gameManager.isGaming == true)
        {
            deltaSpawnTime += Time.deltaTime;
            playingTime += Time.deltaTime;


            if (deltaSpawnTime > spawnTime && playingTime < limitTime)
            {
                deltaSpawnTime = 0;

                Instantiate(box, spawnPoint.position, Quaternion.Euler(0, 90, 0));
            }
        }
    }
}
