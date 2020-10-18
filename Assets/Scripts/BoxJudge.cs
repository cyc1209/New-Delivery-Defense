using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoxJudge : MonoBehaviour
{
    public int mode = 0;
    public GameManager gameManager;
    public SoundManager soundManager;
    public LevelManager levelManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            switch (mode) {
                case 0:
                    if (collision.gameObject.GetComponent<Box>().weight > 3.5f + (1f/gameManager.Level))  //크기
                    {
                        // UnityEngine.Debug.Log("Fail");

                        gameManager.reputation -= 10;
                        levelManager.TotalMinusReputation -= 10;
                        soundManager.PlayUpDownCrashSound();
                        //UnityEngine.Debug.Log(gameManager.reputation);
                    }
                    else
                    {
                        soundManager.PlayCorrectSound();
                    }
                    break;

                case 1:
                    if (collision.gameObject.GetComponent<MeshRenderer>().material.color != Color.red)   //색깔
                    {
                        gameManager.reputation -= 10;
                        levelManager.TotalMinusReputation -= 10;
                        soundManager.PlayUpDownCrashSound();
                    }
                    else
                    {
                        soundManager.PlayCorrectSound();
                    }
                    break;
                case 2:
                    if (collision.gameObject.GetComponent<MeshRenderer>().material.color != Color.blue)   //색깔
                    {
                        gameManager.reputation -= 10;
                        levelManager.TotalMinusReputation -= 10;
                        soundManager.PlayUpDownCrashSound();
                    }
                    else
                    {
                        soundManager.PlayCorrectSound();
                    }
                    break;
                case 3:
                    if (collision.gameObject.GetComponent<MeshRenderer>().material.color != Color.green)   //색깔
                    {
                        gameManager.reputation -= 10;
                        levelManager.TotalMinusReputation -= 10;
                        soundManager.PlayUpDownCrashSound();
                    }
                    else
                    {
                        soundManager.PlayCorrectSound();
                    }
                    break;
                default:
                    break;
            }
            Destroy(collision.gameObject);
        }
    }


}
