using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 *  Second page of the menu screen. Starts the game and sends data to the airtable script for user selection.
 */
public class FormDataInput : MonoBehaviour
{
    [Header("Scripts")]
    public AirtableManager airTable;
    public SceneTransitionManager sceneTransitionManager;

    [Header("UI Elements")]
    public Button startButton;
    public TMPro.TMP_Dropdown turnDropdown;

    [Header("Game Scene")]
    public GameObject scene;

    public string dropdownOutput;

    void Start()
    {
        airTable = FindObjectOfType<AirtableManager>();
        startButton.onClick.AddListener(StartGame);
        turnDropdown.onValueChanged.AddListener(SetAge);
    }

    public void StartGame()
    {
        sceneTransitionManager.GetComponent<Animator>().Play("PulseToBlack");
        // Write dropdownOutput to airtable
        airTable.age = dropdownOutput;

        Debug.Log("Selected option:" + dropdownOutput);
    }
    public void SetAge(int value)
    {
        switch (value) {
            case 0:
                dropdownOutput = "< 11";
                break;
            case 1:
                dropdownOutput = "11 - 18";
                break;
            case 2:
                dropdownOutput = "19 - 30";
                break;
            case 3:
                dropdownOutput = "> 30";
                break;
        }
        
    }

}
