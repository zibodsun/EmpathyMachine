using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveDrawing : MonoBehaviour
{
    public LivingDrawings.drawing drawingType;

    public Transform[] lerpBetweenPoints;
    Transform currentDestination;
    Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = transform.position;
        currentDestination = lerpBetweenPoints[Random.Range(0, lerpBetweenPoints.Length)];
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentDestination.position, 0.6f * Time.deltaTime);
        Quaternion newRotation = Quaternion.LookRotation(currentDestination.position - transform.position);
        newRotation = Quaternion.Euler(-90, newRotation.eulerAngles.y, newRotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.3f*Time.deltaTime);

        if (Vector3.Distance(transform.position, currentDestination.position) < 0.6f)
        {
            currentDestination = lerpBetweenPoints[Random.Range(0, lerpBetweenPoints.Length)];
        }
    }
}
