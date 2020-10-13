using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserInput : MonoBehaviour
{
    public GameObject currentObject;
    public SteamVR_Behaviour_Pose pose;
    public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");
    public SteamVR_Input_Sources input_Sources;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
        //interactWithUI.AddOnStateUpListener(Grab, input_Sources);
    }

    // Update is called once per frame
    private void Update()

   // void Grab(SteamVR_Action_Boolean steamVR_Action_Boolean, SteamVR_Input_Sources steamVR_Input_Sources)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
            currentObject = hit.collider.gameObject;
     
        if (currentObject != null)
        {
            if (interactWithUI != null && interactWithUI.GetState(input_Sources))
            {
                if (currentObject.CompareTag("Box"))
                {
                    currentObject.transform.position += this.transform.forward * - 0.02f; // 물체의 점과 플레이어 점을 선으로 그어서 당기기
                }
            }
        }
    }
}



//대충 coroutine으로 만들기 transform.lerp이용
