using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int reputation = 0; //명성
    public int level = 0; //레벨
    public int gameMode = 0;
    private int timer = 0;
    public GameObject prevUI;
    public bool isGaming = false;

    public int boxCount = 0;
    // Start is called before the first frame update

    public static GameManager instance;

    void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSizeScene()
    {
        SceneManager.LoadScene("SizeScene");
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
        prevUI.SetActive(false);
        isGaming = true;
    }
}
