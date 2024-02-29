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

    Vector3 spawn;
    bool active = false;

    public virtual void Start() { 
        spawn = transform.position;
    }

    public virtual void Update()
    {
        if (active)
        {
            indicator.SetActive(true);
        }

        if (Vector3.Distance(transform.position, spawn) > 50)
        {
            transform.position = spawn;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
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
