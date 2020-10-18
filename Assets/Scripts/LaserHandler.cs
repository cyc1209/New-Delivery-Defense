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

    // Start is called before the first frame update
    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
        selected = false;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
  
        if (e.target.name == "StartButton")
        {
            Debug.Log("Button was clicked");
            gameManager.LoadSizeScene();
        }
        if (e.target.name == "WaveStartButton")
        {
            Debug.Log("Button was clicked");
            gameManager.WaveStart();
        }
        if (e.target.name == "ReStartButton")
        {
            Debug.Log("Button was clicked");
            gameManager.ReStart();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void PointerInside(object sender, PointerEventArgs e)
    {

        if (e.target.name == this.gameObject.name && selected == false)
        {
            selected = true;
            Debug.Log("pointer is inside this object" + e.target.name);
        }
    }
    public void PointerOutside(object sender, PointerEventArgs e)
    {

        if (e.target.name == this.gameObject.name && selected == true)
        {
            selected = false;
            Debug.Log("pointer is outside this object" + e.target.name);
        }
    }
    public bool get_selected_value()
    {
        return selected;
    }
}
