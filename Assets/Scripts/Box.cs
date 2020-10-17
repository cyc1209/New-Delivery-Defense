using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Box : MonoBehaviour
{

    private Interactable interactable;
    private string currentTag;
    private bool touchable;

    public bool breakable = false;
    public bool updown = false;
    public float weight;
    private float colorRandom;
    private float random;

    public GameManager gameManager;

    // 오디오 소스 생성해서 추가

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        interactable = GetComponent<Interactable>();
        //currentTag = this.tag;
        touchable = true;

        random = UnityEngine.Random.Range(1.0f, 10.0f);

        if (random <= 2.0f && random >= 1.0f)
        {
            breakable = true;

        }

        if (gameManager.gameMode == 0)
        {
            weight = UnityEngine.Random.Range(3.0f, 5.0f);
            if (weight <= 4.5f)
                this.transform.localScale = new Vector3(weight * 0.1f, weight * 0.2f, weight * 0.2f);
            else
                this.transform.localScale = new Vector3(weight * 0.2f, weight * 0.4f, weight * 0.4f);
        }
        else if (gameManager.gameMode == 1)
        {
            weight = UnityEngine.Random.Range(3.0f, 5.0f);
            this.transform.localScale = new Vector3(weight * 0.2f, weight * 0.4f, weight * 0.4f);

            colorRandom = UnityEngine.Random.Range(1.0f, 4.0f);
            if (colorRandom >= 1.0f && colorRandom < 2.0f)
                this.GetComponent<MeshRenderer>().material.color = Color.red;
            if (colorRandom >= 2.0f && colorRandom < 3.0f)
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
            if (colorRandom >= 3.0f && colorRandom <= 4.0f)
                this.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (gameManager.gameMode == 2)
        {
            if (random >= 9.0f && random <= 10.0f)
            {
                updown = true;

            }
            weight = UnityEngine.Random.Range(3.0f, 6.0f);
            if (weight <= 4.5f)
                this.transform.localScale = new Vector3(weight * 0.1f, weight * 0.2f, weight * 0.2f);
            else
                this.transform.localScale = new Vector3(weight * 0.2f, weight * 0.4f, weight * 0.4f);
        }


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
        if (collision.relativeVelocity.magnitude > 5 && breakable)
        {
            UnityEngine.Debug.Log("Crash!");
            playSound(audioClip, audioSource);
            //this.GetComponent<MeshRenderer>().material.color = Color.white;
            gameManager.boxCount--;
            Destroy(this.gameObject);
        }

        if (updown && Vector3.Dot(Vector3.up, this.transform.up) <= 0)
        {
            UnityEngine.Debug.Log("down");
            playSound(audioClip, audioSource);
            //this.GetComponent<MeshRenderer>().material.color = Color.white;
            gameManager.boxCount--;
            Destroy(this.gameObject);
        }
    }

    public static void playSound(AudioClip clip, AudioSource source)
    {
        source.Play();
    }
}
