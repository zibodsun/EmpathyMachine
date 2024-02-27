using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Every bullet has a randomised colour between 4.
 */
public class BulletChangeColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        int r = Random.Range(0, 3);

        switch (r) {
            case 0:
                renderer.material.color = Color.red;
                break;
            case 1:
                renderer.material.color = Color.blue;
                break;
            case 2:
                renderer.material.color = Color.green;
                break;
            case 3:
                renderer.material.color = Color.yellow;
                break;
        }
    }
}
