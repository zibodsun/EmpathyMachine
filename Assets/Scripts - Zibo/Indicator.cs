using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public string objectTag;
    public GameObject targetGameObject;

    private GameObject interacted;

    // When the correct object enters the collider, the object gets placed in its target position
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == objectTag) { 
            interacted = other.gameObject;
            interacted.SetActive(false);
            targetGameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
