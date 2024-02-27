using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  Script to receive the turning mode choice from the menu screen and apply it in the XROrigin.
 */
public class SetTurningOptions : MonoBehaviour
{
    public int value;
    public CenterPlayerOnSpawn turnTypeFromPlayerPref;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetTurningOption);
    }

    public void SetTurningOption() {
        PlayerPrefs.SetInt("turn", value);
        turnTypeFromPlayerPref.ApplyPlayerPref();
        Debug.Log("Set turning option to " + value);
    }
}
