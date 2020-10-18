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
            player.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (gameMode == 1)
        {
            player.transform.position = new Vector3(-1.64f, 0.86f, -1.86f);
        }
        else if (gameMode >= 2)
        {
            player.transform.position = new Vector3(-0.47f, 0f, 0.47f);
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
                    if(Level == 3)
                    {
                        LoadEnding();
                    }
                    levelManager.LevelUp();
                    LoadSizeScene();
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
    }

    public void ReStart()
    {
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
        Destroy(levelManager);
        Destroy(soundManager);
        SceneManager.LoadScene("TitleScene");
        gameMode = 3;
        isGaming = false;
    }
    public void LoadSizeScene()
    {
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
