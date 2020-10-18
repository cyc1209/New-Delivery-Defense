using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoxJudge : MonoBehaviour
{
    public int mode = 0;
    public GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            switch (mode) {
                case 0:
                    if (collision.gameObject.GetComponent<Box>().weight > 4.5f)  //크기
                    {
                        // UnityEngine.Debug.Log("Fail");
                        gameManager.reputation -= 10;
                        //UnityEngine.Debug.Log(gameManager.reputation);
                    }
                    break;

                case 1:
                    if (collision.gameObject.GetComponent<MeshRenderer>().material.color != Color.red)   //색깔
                    {
                        gameManager.reputation -= 10;
                    }
                    break;
                case 2:
                    if (collision.gameObject.GetComponent<MeshRenderer>().material.color != Color.blue)   //색깔
                    {
                        gameManager.reputation -= 10;
                    }
                    break;
                case 3:
                    if (collision.gameObject.GetComponent<MeshRenderer>().material.color != Color.green)   //색깔
                    {
                        gameManager.reputation -= 10;
                    }
                    break;
                default:
                    break;
            }
            Destroy(collision.gameObject);
        }
    }


}
