using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new activity", menuName = "ScriptableObjects/NPCActivity")]
public class NPCActivity : ScriptableObject
{
    public string activity;
    public string animationTrigger;
    public Vector3 agentDestination;
    public string dialogueNode;

    public string[] taskObjects;

    public Quaternion rotation;
}
