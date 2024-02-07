using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PathToFollow : MonoBehaviour
{
    public Transform path;          // A gameobject with a number of positions on a path as children
    public NavMeshAgent agent;
    public bool startOnAwake;

    List<Vector3> points = new List<Vector3>();
    int nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in path) {
            points.Add(child.position);
        }

        nextPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startOnAwake) return;

        if (nextPoint < points.Count) {
            agent.SetDestination(points[nextPoint]);
        }

        // reached point
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= 2 && agent.remainingDistance != 0)
            {
                nextPoint++;
            }
        }
    }

    public void StartPath() {
        startOnAwake = true;
    }

    public int GetNextPoint() {
        return nextPoint;
    }
}
