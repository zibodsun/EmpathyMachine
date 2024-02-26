using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Plays the animations of the tracks in the train event.
 */
public class Track : MonoBehaviour
{
    Vector3 growSpeed = new Vector3(0.05f, 0.05f, 0.05f);
    float size;
    public float timer;
    float time;
    bool spawning = true;

    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale.x;
        transform.localScale = transform.localScale * 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (spawning) {
            case true:
                if (transform.localScale.x < size)
                {
                    transform.localScale += growSpeed;
                }
                else {
                    spawning = false;
                }
                break;
            case false:
                if (time <= timer)
                {
                    time += Time.deltaTime;
                }
                else
                {
                    if (transform.localScale.x > 0)
                    {
                        transform.localScale -= growSpeed;
                    }
                    else
                    {
                        spawning = true;
                        gameObject.SetActive(false);
                    }
                }
                break;
        }
    }
}
