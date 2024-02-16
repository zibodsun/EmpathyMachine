using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    Vector3 growSpeed = new Vector3(0.2f, 0.2f, 0.2f);
    float size;

    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale.x;
        transform.localScale = transform.localScale * 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < size) {
            transform.localScale += growSpeed;
        }
    }
}
