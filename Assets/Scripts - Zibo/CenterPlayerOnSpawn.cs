using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 *  Stops XROrigin from spawning out of bounds
 */
public class CenterPlayerOnSpawn : MonoBehaviour
{
    [Header("Recentering XROrigin")]
    public Transform spawn;
    public LocomotionSystem locomotionSystem;
    public float centeringDelay = 0.1f;

    [Header("Player Preference Values")]
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;

    // Start is called before the first frame update
    void Start()
    {
        DisableTurn();

        if (locomotionSystem != null)
        {
            Debug.Log("Disabled locomotion and applied turning options.");
            locomotionSystem.gameObject.SetActive(false);
            ApplyPlayerPref();
        }
        StartCoroutine(Center(centeringDelay));
    }
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, spawn.position) > 100) {
            transform.position = spawn.position;
            Center();
        }
    }

    IEnumerator Center(float wait) {
        yield return new WaitForSeconds(wait);
        XROrigin xrorigin = GetComponent<XROrigin>();

        xrorigin.MoveCameraToWorldLocation(new Vector3(spawn.position.x, xrorigin.Camera.transform.position.y, spawn.position.z));
        xrorigin.MatchOriginUpCameraForward(spawn.up, spawn.forward);

        if (locomotionSystem != null) {
            locomotionSystem.gameObject.SetActive(true);
        }
    }

    void Center()
    {
        XROrigin xrorigin = GetComponent<XROrigin>();

        xrorigin.MoveCameraToWorldLocation(new Vector3(spawn.position.x, xrorigin.Camera.transform.position.y, spawn.position.z));
        xrorigin.MatchOriginUpCameraForward(spawn.up, spawn.forward);
        locomotionSystem.gameObject.SetActive(true);
    }

    public void ApplyPlayerPref()
    {
        snapTurn.enabled = true;
        continuousTurn.enabled = true;

        if (PlayerPrefs.HasKey("turn"))
        {
            int value = PlayerPrefs.GetInt("turn");
            if (value == 0)
            {
                Debug.Log("Set turning option to Snap");
                snapTurn.rightHandSnapTurnAction.action.Enable();
                continuousTurn.rightHandTurnAction.action.Disable();
            }
            else if (value == 1)
            {
                Debug.Log("Set turning option to Continuous");
                snapTurn.rightHandSnapTurnAction.action.Disable();
                continuousTurn.rightHandTurnAction.action.Enable();
            }
        }
    }

    public void DisableTurn() {
        snapTurn.rightHandSnapTurnAction.action.Disable();
        continuousTurn.rightHandTurnAction.action.Disable();
    }
}
