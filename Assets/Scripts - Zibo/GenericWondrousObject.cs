using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Yarn;
using Yarn.Unity;

/*
 *  Manages the placement of wondrous objects in their target position.
 */
public class GenericWondrousObject : MonoBehaviour
{
    public XRBaseInteractable firstInteractor;           // The interaction component that needs to be active to start the wondrous event
    public GameObject indicator;

    bool active = false;

    private void Update()
    {
        if (active)
        {
            indicator.SetActive(true);
        }
    }

    public virtual void OnPickUp() {
        active = true;
        indicator.SetActive(true);
    }

    public virtual void OnDrop()
    {
        active = false;
        indicator.SetActive(false);
    }

    public virtual void OnCorrectlyPlaced()
    {
        active = false;
        indicator.SetActive(false);
    }
    [YarnCommand("activateWondrousProperties")]
    public virtual void ActivateWondrousProperties() {
        firstInteractor.enabled = true;
    }
}
