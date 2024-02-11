using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WondrousEventManager : MonoBehaviour
{
    [Header("Slime Shooting Event")]
    public GameObject slimeShootingEvent;
    public float slimeShootingEventDuration = 15f;
    public FireGun toyGun;
    private bool _slimeEventExecuted;

    [Header("Sword Event")]
    public GameObject swordEvent;
    public float swordEventDuration = 15f;
    public GenericWondrousObject broom;
    private bool _swordEventExecuted;

    public void EnableSlimeShootingEvent() {
        if (_slimeEventExecuted) return;

        _slimeEventExecuted = true;
        slimeShootingEvent.SetActive(true);
        StartCoroutine(StopEvent(slimeShootingEvent, slimeShootingEventDuration));
    }

    public void EnableSwordEvent()
    {
        if (_swordEventExecuted) return;

        _swordEventExecuted = true;
        broom.GetComponent<Animator>().Play("TransformToSword");
        swordEvent.SetActive(true);
        StartCoroutine(StopEvent(swordEvent, swordEventDuration));
    }

    IEnumerator StopEvent(GameObject wondrousEvent, float duration) {
        yield return new WaitForSeconds(duration);
        wondrousEvent.SetActive(false);
    }
}
