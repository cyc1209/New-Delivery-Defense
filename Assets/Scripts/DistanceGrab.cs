using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class DistanceGrab : MonoBehaviour
{
    public Transform pointer;//the transform the laser starts at
    public LayerMask thingsWeCanGrab;//things we can grab

    Hand hand;//our hand
    bool isAttached = false;//do we have something in our hand?
    GameObject attachedObject = null;//what do we have in our hand

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<Hand>();//get our hand
    }
    // Update is called once per frame
    void Update()
    {
        //raycast and check if our hand is empty
        RaycastHit hit;
        if (Physics.Raycast(pointer.position, pointer.forward, out hit, 10f, thingsWeCanGrab) && hand.currentAttachedObject == null)
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            SteamVR_Input_Sources source = hand.handType;
            //are we pressing grip and trigger?
            if (hand.grabGripAction[source].state == true && hand.grabPinchAction[source].state == true)
            {
                //does the interactable component exist?
                if (interactable != null)
                {
                    //move the object to your hand
                    interactable.transform.LookAt(transform);
                    interactable.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500, ForceMode.Force);
                    attachedObject = interactable.gameObject;
                    isAttached = true;
                    //attaching to hand is in the late update function
                }
            }
           
        }
  
    }
    private void LateUpdate()
    {
        //did we get an object to our hand during this update?
        if (isAttached)
        {
            //attach the object
            hand.AttachObject(attachedObject, GrabTypes.Grip);
            attachedObject = null;
            isAttached = false;
        }
    }
}