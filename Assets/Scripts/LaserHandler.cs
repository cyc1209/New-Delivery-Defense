using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class LaserHandler : MonoBehaviour
{
    public SteamVR_Behaviour_Pose pose;
    public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");
    public SteamVR_LaserPointer laserPointer;
    public GameObject hand;
    public bool selected;
    public GameManager gameManager;
    public SoundManager soundManager;


    // Start is called before the first frame update
    void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hand = GameObject.Find("RightHand");
        laserPointer = GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerClick += PointerClick;
        selected = false;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
  
        if (e.target.name == "StartButton")
        {
            Debug.Log("Button was clicked");
            soundManager.PlayButtonClickSound();
            gameManager.LoadSizeScene();
        }
        if (e.target.name == "WaveStartButton")
        {
            Debug.Log("Button was clicked");
            soundManager.PlayButtonClickSound();
            gameManager.WaveStart();
        }
        if (e.target.name == "ReStartButton")
        {
            Debug.Log("Button was clicked");
            soundManager.PlayButtonClickSound();
            gameManager.ReStart();
        }
        if (e.target.name == "MainButton")
        {
            Debug.Log("Button was clicked");
            soundManager.PlayButtonClickSound();
            gameManager.LoadMainScene();
        }
    }
    // Update is called once per frame
   
}
