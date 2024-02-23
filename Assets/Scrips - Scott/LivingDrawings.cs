using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;
using Random = System.Random;

public class LivingDrawings : MonoBehaviour
{
    public bool finishDrawing = false;
    public enum drawing
    {
        fish,
        horse,
        bird,
        monkey
    }

    public Transform[] lerpPositions;

    drawing currentDrawing;
    public TextMeshProUGUI drawPrompt;
    public GameObject livingDrawing;


    [YarnCommand("startDrawing")]
    public void startDrawingTask()
    {
        drawPrompt.enabled = true;
        newDrawing();
    }

    public void createDrawing()
    {
        Transform myDrawing = Instantiate(livingDrawing, transform.position, transform.rotation).transform;
        myDrawing.GetComponent<LiveDrawing>().lerpBetweenPoints = lerpPositions;

        foreach(LineRenderer line in transform.GetComponentsInChildren<LineRenderer>())
        {
            line.transform.SetParent(myDrawing);
            line.useWorldSpace = false;
        }

        newDrawing();
    }

    void newDrawing()
    {
        Array values = Enum.GetValues(typeof(drawing));
        Random random = new Random();
        currentDrawing = (drawing)values.GetValue(random.Next(values.Length));
        drawPrompt.text = "Draw A " + currentDrawing.ToString();
    }

    private void Update()
    {
        if (finishDrawing)
        {
            finishDrawing = false;
            createDrawing();
        }
    }
}
