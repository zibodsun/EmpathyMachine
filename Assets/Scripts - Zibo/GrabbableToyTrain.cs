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

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        simpInteractable = GetComponent<XRSimpleInteractable>();
    }

    private void Update()
    {
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
