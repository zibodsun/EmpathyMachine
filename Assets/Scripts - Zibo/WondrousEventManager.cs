using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Toggles on and off the wondrous events and sets their duration.
 */
public class WondrousEventManager : MonoBehaviour
{
    [Header("Data Storage")]
    public AirtableManager airTable;

    [Header("Slime Shooting Event")]
    public GameObject slimeShootingEvent;
    public float slimeShootingEventDuration = 15f;
    public FireGun toyGun;
    private bool _slimeEventExecuted;

    [Header("Sword Event")]
    public GameObject swordEvent;
    public float swordEventDuration = 15f;
    public Broom broom;
    private bool _swordEventExecuted;

    [Header("Train Event")]
    public GameObject trainEvent;
    public AnimationClip startTrainAnimation;
    public AnimationClip activeTrainAnimation;
    private bool _trainEventExecuted;

    private void Awake()
    {
        airTable = FindObjectOfType<AirtableManager>();
        airTable.CreateRecord();
    }

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
        broom.isSword = true;
        swordEvent.SetActive(true);
        StartCoroutine(StopEvent(swordEvent, swordEventDuration + 3f));    // sword event is interrupted in its own script
    }

    public void EnableTrainEvent() {
        if (_trainEventExecuted) return;

        _trainEventExecuted = true;
        trainEvent.SetActive(true);
        StartCoroutine(StopEvent(trainEvent, activeTrainAnimation.length + startTrainAnimation.length + 3f));
    }

    IEnumerator StopEvent(GameObject wondrousEvent, float duration) {
        yield return new WaitForSeconds(duration);
        wondrousEvent.SetActive(false);
    }
}
