using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class HareNPCManager : MonoBehaviour
{
    public Animator animator;
    public NPCActivity[] activities;
    Dictionary<string, NPCActivity> activityLookup = new Dictionary<string, NPCActivity>();
    public NavMeshAgent agent;
    public NPC3D hare;

    string currentActivity;

    private void Start()
    {
        currentActivity = activities[0].activity;

        foreach(NPCActivity activity in activities)
        {
            activityLookup.Add(activity.activity, activity);
        }

        updateActivity();
    }

    private void Update()
    {
        if(agent.velocity.sqrMagnitude <= 0.1f)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, activityLookup[currentActivity].rotation.eulerAngles, Time.deltaTime * 0.6f));           
        }

        animator.SetFloat("speed", agent.velocity.sqrMagnitude);
    }

    [YarnCommand("setActivity")]
    public void setActivity(string activity)
    {
        currentActivity = activity;
        updateActivity();
    }

    void updateActivity()
    {
        hare.talkToNode = activityLookup[currentActivity].dialogueNode;
        animator.SetTrigger(activityLookup[currentActivity].animationTrigger);
        agent.SetDestination(activityLookup[currentActivity].agentDestination);
    }
}
