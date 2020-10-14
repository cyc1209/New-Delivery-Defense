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
    public SteamVR_Action_Boolean grabGrip = SteamVR_Input.GetBooleanAction("GrabGrip");
    public SteamVR_Input_Sources input_Sources;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
            currentObject = hit.collider.gameObject;
     
        if (currentObject != null)
        {
            if (grabGrip != null && grabGrip.GetState(input_Sources))
            {
                if (currentObject.CompareTag("Box"))
                {
                    StartCoroutine("Grab");
                }
            }
        }
    }

    IEnumerator Grab()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            currentObject.transform.position = Vector3.Lerp(currentObject.transform.position, this.transform.position, Time.deltaTime * f); // 물체의 점과 플레이어 점을 선으로 그어서 당기기
        }
        yield return null;
    }
}


// 변수로 시작점 만들고 속도 변수도 만들고 하면 될듯
//대충 coroutine으로 만들기 transform.lerp이용
