using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BoxSpawner : MonoBehaviour
{
    float spawnTime;
    private float limitTime = 11;
    public Transform spawnPoint;
    public GameObject box;
    float deltaSpawnTime;
    float playingTime = 0;
    public GameManager gameManager;

    public float LimitTime { get => limitTime; set => limitTime = value; }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetSpwanSettings();
    }
    void Update()
    {
        if (gameManager.isGaming == true)
        {
            //UnityEngine.Debug.Log(playingTime+","+spawnTime);
            deltaSpawnTime += Time.deltaTime;
            playingTime += Time.deltaTime;


            if (deltaSpawnTime > spawnTime && playingTime < LimitTime)
            {
                deltaSpawnTime = 0;
                //UnityEngine.Debug.Log("spawning");
                Instantiate(box, spawnPoint.position, Quaternion.Euler(0, 90, 0));
            }
        }
    }
    public void SetSpwanSettings()
    {
        playingTime = 0;
        if (gameManager.gameMode == 0)
        {
            spawnTime = (1.5f / gameManager.Level);
        }
        else
        {
            spawnTime = (2.5f / gameManager.Level);
        }
    }
}
