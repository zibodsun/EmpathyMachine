using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTracks : MonoBehaviour
{
    List<GameObject> tracks = new();
    int index;
    float timer;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        timer = .5f;

        foreach (Transform child in transform)
        {
            tracks.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time < timer)
        {
            time += Time.deltaTime;
        }
        else {
            time = 0f;
            if (index < tracks.Count)
            {
                tracks[index].SetActive(true);
                tracks[index].GetComponent<Track>().timer = 20f - index;
                index++;
            }
        }
    }
}
