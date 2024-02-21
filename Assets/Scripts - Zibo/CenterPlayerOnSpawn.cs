using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

/*
 *  Stops XROrigin from spawning out of bounds
 */
public class CenterPlayerOnSpawn : MonoBehaviour
{
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Center());
    }

    IEnumerator Center() {
        yield return new WaitForSeconds(1f);
        XROrigin xrorigin = GetComponent<XROrigin>();

        xrorigin.MoveCameraToWorldLocation(new Vector3(spawn.position.x, xrorigin.Camera.transform.position.y, spawn.position.z));
        xrorigin.MatchOriginUpCameraForward(spawn.up, spawn.forward);
    }
}
