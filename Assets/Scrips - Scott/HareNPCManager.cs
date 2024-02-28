using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Collider trigger;

    public GameObject feedbackForm;

    string currentActivity;

    private void Start()
    {
        currentActivity = activities[0].activity;

        foreach(NPCActivity activity in activities)
        {
            activityLookup.Add(activity.activity, activity);
        }

        UpdateActivity();
    }

    private void Update()
    {
        if(agent.velocity.sqrMagnitude <= 0.1f)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, activityLookup[currentActivity].rotation.eulerAngles, Time.deltaTime * 0.6f));           
        }

        animator.SetFloat("speed", agent.velocity.sqrMagnitude);

        CheckTaskComplete();
    }

    [YarnCommand("setActivity")]
    public void SetActivity(string activity)
    {
        currentActivity = activity;
        UpdateActivity();
    }

    void UpdateActivity()
    {
        hare.talkToNode = activityLookup[currentActivity].dialogueNode;
        animator.SetTrigger(activityLookup[currentActivity].animationTrigger);
        agent.SetDestination(activityLookup[currentActivity].agentDestination);
    }

    [YarnCommand("activate")]
    public void ActivateObject(string targetObject)
    {
        GameObject toActivate = GameObject.Find(targetObject);

        if (toActivate!=null)
        {
            toActivate.SetActive(true);
        }
    }

    public void CheckTaskComplete()
    {
        bool complete = true;
        string[] taskObjects = activityLookup[currentActivity].taskObjects;

        complete = taskObjects.Length > 0;

        foreach(string taskObject in taskObjects)
        {
            if (GameObject.Find(taskObject) == null)
            {
                complete = false;
            }
        }

        if (complete)
        {
            hare.talkToNode = "chooseTask";
        }
    }

    [YarnCommand ("feedback")]
    public void ActivateFeedbackForm()
    {
        feedbackForm.SetActive(true);
    }
}
