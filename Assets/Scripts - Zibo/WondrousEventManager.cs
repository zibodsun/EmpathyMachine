using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WondrousEventManager : MonoBehaviour
{
    public GameObject SlimeShootingEvent;
    public float SlimeShootingEventDuration = 15f;
    public FireGun toyGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableSlimeShootingEvent() {
        SlimeShootingEvent.SetActive(true);
        StartCoroutine(StopEvent(SlimeShootingEvent, SlimeShootingEventDuration));
    }

    IEnumerator StopEvent(GameObject wondrousEvent, float duration) {
        yield return new WaitForSeconds(duration);
        wondrousEvent.SetActive(false);
    }
}
