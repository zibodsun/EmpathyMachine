using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericWondrousObject : MonoBehaviour
{
    public GameObject indicator;

    public virtual void OnPickUp() { 
        indicator.SetActive(true);
    }

    public virtual void OnCorrectlyPlaced()
    {
        indicator.SetActive(false);
    }
}
