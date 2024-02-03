using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Runner
{
    public float speed = 1f;

    public void SpeedUp()
    {
        speed += 1f;
    }

    public void StartRun()
    {
        agent.speed = speed;
    }
}
