using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormDataInput : MonoBehaviour
{
    public SceneTransitionManager sceneTransitionManager;
    public Button startButton;
    public GameObject scene;
    public TMPro.TMP_Dropdown turnDropdown;

    public int dropdownOutput;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        turnDropdown.onValueChanged.AddListener(SetTurnPlayerPref);
    }

    public void StartGame()
    {
        sceneTransitionManager.GetComponent<Animator>().Play("PulseToBlack");
        // Write dropdownOutput to airtable
        Debug.Log("Selected option:" + dropdownOutput);
    }
    public void SetTurnPlayerPref(int value)
    {
        dropdownOutput = value;
        
    }

}
