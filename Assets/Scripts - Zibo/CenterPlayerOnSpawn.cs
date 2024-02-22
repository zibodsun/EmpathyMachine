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
    public Transform spawn;
    public LocomotionSystem locomotionSystem;

    // Start is called before the first frame update
    void Start()
    {
        if(locomotionSystem != null)
        {
            locomotionSystem.gameObject.SetActive(false);
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
        locomotionSystem.gameObject.SetActive(true);
    }

    void Center()
    {
        XROrigin xrorigin = GetComponent<XROrigin>();

        xrorigin.MoveCameraToWorldLocation(new Vector3(spawn.position.x, xrorigin.Camera.transform.position.y, spawn.position.z));
        xrorigin.MatchOriginUpCameraForward(spawn.up, spawn.forward);
        locomotionSystem.gameObject.SetActive(true);
    }
}
