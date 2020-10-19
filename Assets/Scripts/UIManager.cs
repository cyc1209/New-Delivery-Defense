using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    private LevelManager levelManager;
    public Text repText;
    public Text timerText;
    public Text countText;
    public Text levelText;
    public GameObject prevUI;
    public GameObject ingameUI;
    public GameObject gameoverUI;
    public GameObject endingUI;

    public Text totalCountText;
    public Text totalCrashText;
    public Text totalMinusText;
    public Text totalScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelText != null)
            levelText.text = gameManager.Level + "일차";
        if (gameManager.isGaming)
        {
            repText.text = "평판: " + gameManager.reputation;
            timerText.text = "남은 시간: " + Mathf.Ceil(gameManager.Timer).ToString();
            if (countText != null)
                countText.text = "실은 개수: " + gameManager.boxCount;
        }
    }

    public void HidePrevUI()
    {
        prevUI.SetActive(false);
    }

    public void ShowPrevUI()
    {
        prevUI.SetActive(true);
    }

    public void HideIngameUI()
    {
        ingameUI.SetActive(false);
    }

    public void ShowIngameUI()
    {
        ingameUI.SetActive(true);
    }

    public void HideGameOverUI()
    {
        gameoverUI.SetActive(false);
    }
    public void ShowGameOverUI()
    {
        gameoverUI.SetActive(true);
    }

    public void ShowEndingUI()
    {
        endingUI.SetActive(true);
        totalCountText.text = "총"+ levelManager.TotalCountBox + "개 실음.";
        totalCrashText.text = "총" + levelManager.TotalCountCrash + "개 파손됨.";
        totalMinusText.text = "총" + levelManager.TotalMinusReputation + "점 잃음.";
        totalScoreText.text = "총" + levelManager.CalcScore() +"점";
    }
}
