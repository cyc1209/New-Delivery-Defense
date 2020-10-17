﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
 //Make sure to assign this in the Inspector window
    Collider m_Collider;
    private GameManager gameManager;

    void Start()
    {
        //Fetch the Collider from the GameObject this script is attached to
        m_Collider = GetComponent<Collider>();
    }

    void Update()
    {
        //If the first GameObject's Bounds contains the Transform's position, output a message in the console

    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_Collider.bounds.Contains(other.transform.position))
        {
            gameManager.boxCount ++;
        }
    }
}
