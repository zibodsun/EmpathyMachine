using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maintainPosition : MonoBehaviour
{
    public Vector3 position;

    private void Update()
    {
        transform.localPosition = position;
    }
}
