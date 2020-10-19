using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Box : MonoBehaviour
{

    private Interactable interactable;
    private string currentTag;
    public bool touchable;

    public bool breakable = false;
    public bool updown = false;
    public float weight;
    private float colorRandom;
    private float random;

    public GameManager gameManager;
    public SoundManager soundManager;
    public LevelManager levelManager;

    public GameObject updownObj;
    public GameObject glassObj;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        interactable = GetComponent<Interactable>();
        //currentTag = this.tag;
        touchable = true;

        random = UnityEngine.Random.Range(1.0f, 10.0f);

        if (random <= 1.0f+(gameManager.Level) && random >= 1.0f)
        {
            breakable = true;
            glassObj.SetActive(true);

        }

        if (gameManager.gameMode == 0)
        {
            weight = UnityEngine.Random.Range(3.0f, 5.0f);
            if (weight <= (3.5f + (1f/gameManager.Level)))
                this.transform.localScale = new Vector3(weight * 0.1f, weight * 0.2f, weight * 0.2f);
            else
                this.transform.localScale = new Vector3(weight * 0.15f, weight * 0.3f, weight * 0.3f);
        }
        else if (gameManager.gameMode == 1)
        {
            weight = UnityEngine.Random.Range(3.0f, 5.0f);
            this.transform.localScale = new Vector3(weight * 0.15f, weight * 0.3f, weight * 0.3f);

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
            if (random >= 10.0f - (gameManager.Level/3) && random <= 10.0f)
            {
                updown = true;
                updownObj.SetActive(true);
            }
            weight = UnityEngine.Random.Range(3.0f, 5.0f);
            if (weight <= 4f)
                this.transform.localScale = new Vector3(weight * 0.1f, weight * 0.2f, weight * 0.2f);
            else
                this.transform.localScale = new Vector3(weight * 0.15f, weight * 0.3f, weight * 0.3f);
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
        if (!(gameManager.isGaming))
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 6 && breakable)
        {
            UnityEngine.Debug.Log("Crash!");
            soundManager.PlayGlassCrashSound();
            levelManager.TotalCountCrash += 1;
            //this.GetComponent<MeshRenderer>().material.color = Color.white;
            if (!touchable)
            {
                gameManager.boxCount--;
                levelManager.TotalCountBox -= 1;
            }
            Destroy(this.gameObject);
        }

        if (updown && Vector3.Dot(Vector3.up, this.transform.up) <= 0)
        {
            //this.GetComponent<MeshRenderer>().material.color = Color.white;
            if (!touchable)
            {
                UnityEngine.Debug.Log("down");
                soundManager.PlayUpDownCrashSound();
                levelManager.TotalCountCrash += 1;
                gameManager.boxCount--;
                levelManager.TotalCountBox -= 1;
                Destroy(this.gameObject);
            }
        }
    }

}
