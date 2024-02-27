using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UselessScript : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward, ForceMode.Impulse);
        rb.AddTorque(transform.up);
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 1f) {
            transform.localScale += new Vector3(0.1f,0.1f,0.1f);
        }
    }
}
