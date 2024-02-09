using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WondrousEventManager : MonoBehaviour
{
    public GameObject slimeShootingEvent;
    public float slimeShootingEventDuration = 15f;
    public FireGun toyGun;
    private bool _slimeEventExecuted;

    public void EnableSlimeShootingEvent() {
        if (_slimeEventExecuted) return;

        _slimeEventExecuted = true;
        slimeShootingEvent.SetActive(true);
        StartCoroutine(StopEvent(slimeShootingEvent, slimeShootingEventDuration));
    }

    IEnumerator StopEvent(GameObject wondrousEvent, float duration) {
        yield return new WaitForSeconds(duration);
        wondrousEvent.SetActive(false);
    }
}
