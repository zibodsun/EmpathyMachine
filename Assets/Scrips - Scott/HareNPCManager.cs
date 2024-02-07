using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class HareNPCManager : MonoBehaviour
{
    public Animator animator;
    public Transform[] sequencePositions;
    public string[] sequenceTriggers;
    public NavMeshAgent agent;
    public NPC3D hare;

    int sequence = 0;

    private void Update()
    {
        hare.talkToNode = "sequence" + sequence;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TriggerNewSequence();
        }
    }

    [YarnCommand("setSequence")]
    public void SetSequence(int number)
    {
        sequence = number;
        TriggerNewSequence();
    }

    void TriggerNewSequence()
    {
        animator.SetTrigger(sequenceTriggers[sequence]);
        agent.SetDestination(sequencePositions[sequence].position);
        Debug.Log(sequencePositions[sequence].position);
        Debug.Log(transform.position);
    }
}
