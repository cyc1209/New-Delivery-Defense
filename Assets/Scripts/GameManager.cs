using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int reputation = 0; //명성
    private int level; //레벨
    public int gameMode = 3;
    private float timer = 0;
    public bool isGaming = false;
    public BoxSpawner boxSpawner;
    public UIManager uIManager;
    public GameObject player;
    private LevelManager levelManager;
    private SoundManager soundManager;

    public int boxCount = 0;
    // Start is called before the first frame update

    public static GameManager instance;

    public float Timer { get => timer; set => timer = value; }
    public int Level { get => level; set => level = value; }

    void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;

        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        boxSpawner = GameObject.Find("SpawnPoint").GetComponent<BoxSpawner>();

        player = GameObject.Find("Player");
        Level = levelManager.Level;
    }


    void Start()
    {
        if(boxSpawner != null)
         timer = boxSpawner.LimitTime + 10.0f;
        reputation = 100;
        Level = levelManager.Level;

        if (gameMode == 0)
        {
           player.transform.position = new Vector3(-6.5f, 0.25f, -2.07f);
            player.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (gameMode == 1)
        {
            player.transform.position = new Vector3(-2f, 0.86f, -0.5f);
            player.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (gameMode == 2)
        {
            player.transform.position = new Vector3(0f, 0f, -0.47f);
            player.transform.eulerAngles = new Vector3(0, -45, 0);
        }
        else if (gameMode == 3)
        {
            player.transform.position = new Vector3(0f, 0f, -0.7f);
            player.transform.eulerAngles = new Vector3(0, -45, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGaming)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                WaveEnd();
                if(gameMode == 0)
                {
                    LoadColorScene();
                }else if(gameMode == 1)
                {
                    LoadTruckScene();
                }else if(gameMode == 2)
                {
                    if (Level == 3)
                    {
                        LoadEnding();
                    }
                    else
                    {
                        levelManager.LevelUp();
                        LoadSizeScene();
                    }
                }
            }
            if(reputation <= 0)
            {
                GameOver();
            }
;        }
    }

    private void LoadEnding()
    {
        isGaming = false;
        uIManager.ShowEndingUI();
        uIManager.HideIngameUI();
        uIManager.HidePrevUI();
    }

    public void ReStart()
    {
        boxSpawner = GameObject.Find("SpawnPoint").GetComponent<BoxSpawner>();
        boxSpawner.SetSpwanSettings();
        timer = boxSpawner.LimitTime + 10.0f;
        reputation = 100;
        uIManager.HidePrevUI();
        uIManager.ShowIngameUI();
        uIManager.HideGameOverUI();
        isGaming = true;
    }

    private void GameOver()
    {
        isGaming = false;
        uIManager.ShowGameOverUI();
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
        gameMode = 3;
        isGaming = false;
    }
    public void LoadSizeScene()
    {
        if(gameMode == 3)
        {
            levelManager.Level = 1;
            Level = levelManager.Level;
        }
        SceneManager.LoadScene("SizeScene");
        Debug.Log(Level);
        gameMode = 0;
        isGaming = false;
    }
    public void LoadColorScene()
    {
        SceneManager.LoadScene("ColorScene");
        gameMode = 1;
        isGaming = false;
    }
    public void LoadTruckScene()
    {
        SceneManager.LoadScene("TruckScene");
        gameMode = 2;
        isGaming = false;
    }

    public void WaveStart()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        uIManager.HidePrevUI();
        uIManager.ShowIngameUI();
        isGaming = true;
    }

    public void WaveEnd()
    {
        isGaming = false;
        uIManager.ShowPrevUI();
        uIManager.HideIngameUI();
    }
}
