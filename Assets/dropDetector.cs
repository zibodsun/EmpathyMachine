using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.LogError("Drop detected");
        }
    }

}
