using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hare : Runner
{
    public void StopRun() {
        agent.speed = 0f;
    }
    public void StartRun()
    {
        agent.speed = 4f;
    }
}
