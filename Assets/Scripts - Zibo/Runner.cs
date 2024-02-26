using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 *  A navmesh agent that will follow a set path in the Dream scene. Parent class of the Hare and Tortoise.
 */
public class Runner : MonoBehaviour
{
    public PathToFollow path;
    public Animator anim;

    public NavMeshAgent agent;

    public virtual void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void Update() {
        anim.SetInteger("nextPoint", path.GetNextPoint());
    }

    public virtual void BeginRunningSequence() {
        path.StartPath();
    }
}
