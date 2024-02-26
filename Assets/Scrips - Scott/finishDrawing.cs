using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishDrawing : MonoBehaviour
{
    public LivingDrawings ld;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Marker")
        {
            ld.createDrawing();
        }
    }
}
