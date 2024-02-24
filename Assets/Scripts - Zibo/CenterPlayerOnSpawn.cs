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

    [Header("Player Preference Values")]
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;

    // Start is called before the first frame update
    void Start()
    {
        if(locomotionSystem != null)
        {
            locomotionSystem.gameObject.SetActive(false);
            ApplyPlayerPref();
        }
        StartCoroutine(Center(0.1f));
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
        if (PlayerPrefs.HasKey("turn"))
        {
            int value = PlayerPrefs.GetInt("turn");
            if (value == 0)
            {
                snapTurn.leftHandSnapTurnAction.action.Enable();
                snapTurn.rightHandSnapTurnAction.action.Enable();
                continuousTurn.leftHandTurnAction.action.Disable();
                continuousTurn.rightHandTurnAction.action.Disable();
            }
            else if (value == 1)
            {
                snapTurn.leftHandSnapTurnAction.action.Disable();
                snapTurn.rightHandSnapTurnAction.action.Disable();
                continuousTurn.leftHandTurnAction.action.Enable();
                continuousTurn.rightHandTurnAction.action.Enable();
            }
        }
    }
}
