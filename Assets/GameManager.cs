using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int reputation = 0; //명성
    public int level = 0; //레벨
    public int gameMode = 0;
    private float timer = 0;
    public bool isGaming = false;
    public BoxSpawner boxSpawner;
    public UIManager uIManager;
    public GameObject player;

    public int boxCount = 0;
    // Start is called before the first frame update

    public static GameManager instance;

    public float Timer { get => timer; set => timer = value; }

    void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }


    void Start()
    {
        timer = boxSpawner.limitTime + 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGaming)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                WaveEnd();
                if(gameMode == 0)
                {
                    LoadColorScene();
                }else if(gameMode == 1)
                {
                    LoadTruckScene();
                }
            }

        }
    }

    public void LoadSizeScene()
    {
        Destroy(player);
        SceneManager.LoadScene("SizeScene");
        gameMode = 0;
        isGaming = false;
    }
    public void LoadColorScene()
    {
        Destroy(player);
        SceneManager.LoadScene("ColorScene");
        gameMode = 1;
        isGaming = false;
    }
    public void LoadTruckScene()
    {
        Destroy(player);
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
