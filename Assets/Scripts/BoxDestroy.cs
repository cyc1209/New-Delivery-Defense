using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    public GameManager gameManager;
    public SoundManager soundManager;
    private LevelManager levelManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager.gameMode == 0)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                if (collision.gameObject.GetComponent<Box>().weight <= 3.5f + (1f/ gameManager.Level))
                {
                    soundManager.PlayUpDownCrashSound();
                    gameManager.reputation -= 10;
                    levelManager.TotalMinusReputation -= 10;
                }
                Destroy(collision.gameObject);
            }
        }
        else if (gameManager.gameMode == 1)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                gameManager.reputation -= 10;
                levelManager.TotalMinusReputation -= 10;
                Destroy(collision.gameObject);
            }
        }
    }
}
