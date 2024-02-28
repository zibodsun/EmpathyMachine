using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UselessScript : MonoBehaviour
{
    public UnityEngine.Object[] obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = FindObjectsOfType(typeof(AudioListener));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
