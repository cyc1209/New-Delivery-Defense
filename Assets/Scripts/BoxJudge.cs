using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoxJudge : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            if(collision.gameObject.GetComponent<Box>().weight > 4.5f)  //크기
            {
                UnityEngine.Debug.Log("Fail");
            }

            if(collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.red)   //색깔
            {
                UnityEngine.Debug.Log("Fail");
            }
        }
    }
}
