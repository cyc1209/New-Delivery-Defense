using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public float spawnTime = 2.0f;
    public float limitTime = 20f;
    public Transform spawnPoint;
    public GameObject box;
    float deltaSpawnTime;
    float playingTime = 0;
    
    void Update()
    {
        deltaSpawnTime += Time.deltaTime;
        playingTime += Time.deltaTime;
        
       
        if(deltaSpawnTime > spawnTime && playingTime < limitTime)
        {
            deltaSpawnTime = 0;

            Instantiate(box, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
