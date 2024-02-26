using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker : MonoBehaviour
{
    public Color penColour;

    public GameObject drawing;
    public float distanceBetweenPositions;

    LineRenderer currentLineRenderer;
    float drawingY = 0;

    int currentLength = 2;
    bool activelyDrawing = false;

    private void Update()
    {
        if (activelyDrawing)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = drawingY;

            Vector3[] positions = new Vector3[currentLength];
            currentLineRenderer.GetPositions(positions);

            if (Vector3.Distance(newPosition, positions[currentLength - 2]) >= distanceBetweenPositions)
            {
                currentLength++;
                currentLineRenderer.positionCount++;
                currentLineRenderer.SetPosition(currentLength - 1, newPosition);
            }
            else
            {
                currentLineRenderer.SetPosition(currentLength - 1, newPosition);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = other.transform.position.y;
            drawingY = newPosition.y;

            activelyDrawing = true;

            currentLineRenderer = Instantiate(drawing, other.transform.position, Quaternion.identity).GetComponent<LineRenderer>();
            currentLineRenderer.transform.SetParent(other.transform);
            currentLineRenderer.transform.position -= other.transform.position;
            currentLineRenderer.startColor = penColour;
            currentLineRenderer.endColor = penColour;
            currentLength = 2;

            currentLineRenderer.SetPosition(0, newPosition);
            currentLineRenderer.SetPosition(1, newPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            activelyDrawing = false;
        }
    }
}
