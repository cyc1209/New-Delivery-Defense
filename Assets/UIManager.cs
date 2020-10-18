using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public Text repText;
    public Text timerText;
    public Text countText;
    public GameObject prevUI;
    public GameObject ingameUI;
    public GameObject gameoverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGaming)
        {
            repText.text = "명성치: " + gameManager.reputation;
            timerText.text = "남은 시간: " + Mathf.Ceil(gameManager.Timer).ToString();
            if(countText != null)
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
}
