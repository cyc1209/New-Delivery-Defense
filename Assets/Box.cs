using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Box : MonoBehaviour
{

    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
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
        
        if(interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
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
}
