using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Box : MonoBehaviour
{

    private Interactable interactable;
    private string currentTag;
    private bool touchable;

    private bool breakable = false;
    public float weight;
    private float colorRandom;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        currentTag = this.tag;
        touchable = true;
        weight = UnityEngine.Random.Range(3.0f, 5.0f);
        this.transform.localScale = new Vector3(weight * 0.1f, weight * 0.2f, weight * 0.2f);
        colorRandom = UnityEngine.Random.Range(1.0f, 4.0f);
        if (colorRandom >= 1.0f && colorRandom < 2.0f)
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        if (colorRandom >= 2.0f && colorRandom < 3.0f)
            this.GetComponent<MeshRenderer>().material.color = Color.blue ;
        if (colorRandom >= 3.0f && colorRandom <= 4.0f)
            this.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    private Hand.AttachmentFlags attachmentFlags =
        Hand.defaultAttachmentFlags
        & (~Hand.AttachmentFlags.SnapOnAttach)
        & (~Hand.AttachmentFlags.DetachOthers)
        & (~Hand.AttachmentFlags.VelocityMovement);


    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (touchable == true && interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            hand.HoverLock(interactable);
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverLock(interactable);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Conveyor"))
        {
            touchable = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2 && breakable)
        {
            UnityEngine.Debug.Log("Crash!");
        }
    }
