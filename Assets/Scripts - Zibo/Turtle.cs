using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turtle : Runner
{
    public float speed = 1f;

    public override void Update() {
        base.Update();

        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void SpeedUp()
    {
        speed += 1f;
    }

    public void StartRun()
    {
        agent.speed = speed;
    }
}
