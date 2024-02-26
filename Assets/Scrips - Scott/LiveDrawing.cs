using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveDrawing : MonoBehaviour
{
    public LivingDrawings.drawing drawingType;

    public Vector3 firstDestinationOffset;
    public Transform[] lerpBetweenPoints;
    Vector3 currentDestination;

    private void Start()
    {
        currentDestination = transform.position + firstDestinationOffset;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentDestination, 0.6f * Time.deltaTime);
        Quaternion newRotation = Quaternion.LookRotation(currentDestination - transform.position);
        newRotation = Quaternion.Euler(-90, newRotation.eulerAngles.y, newRotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.3f*Time.deltaTime);

        if (Vector3.Distance(transform.position, currentDestination) < 0.6f)
        {
            currentDestination = lerpBetweenPoints[Random.Range(0, lerpBetweenPoints.Length)].position;
        }
    }
}
