using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
/*
 *  Script that controls the interactors that are active on the train object
 */
public class GrabbableToyTrain : GenericWondrousObject
{
    public GameObject trainEvent;

    Renderer rend;
    XRSimpleInteractable simpInteractable;
    XRGrabInteractable grabInteractable;

    public override void Start()
    {
        base.Start();
        rend = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        simpInteractable = GetComponent<XRSimpleInteractable>();
    }

    public override void Update()
    {
        base.Update();
        if (trainEvent.activeSelf == true)
        {
            AnimatedEventStarted();
        }
        else if (rend.enabled == false){
            AnimatedEventEnded();
        }
    }
    public void AnimatedEventStarted() {
        rend.enabled = false;
    }
    public void AnimatedEventEnded() {
        rend.enabled = true;
        simpInteractable.enabled = false;
        grabInteractable.enabled = true;
    }
}
