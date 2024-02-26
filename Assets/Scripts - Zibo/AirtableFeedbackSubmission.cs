using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 *  Final form shown at the end of the app. Submits data for AirTable storage as strings containing a rating from 1 - 5.
 */
public class AirtableFeedbackSubmission : MonoBehaviour
{
    [Header("Scripts")]
    public AirtableManager airtableManager;

    [Header("Feedback Data")]
    public TMPro.TMP_Dropdown liveDrawing;
    public TMPro.TMP_Dropdown toyGun;
    public TMPro.TMP_Dropdown train;
    public TMPro.TMP_Dropdown swordGame;

    [Header("Buttons")]
    public Button submitAndQuit;

    void Awake()
    {
        airtableManager = FindObjectOfType<AirtableManager>();

        liveDrawing.onValueChanged.AddListener(LiveDrawingSetRating);
        toyGun.onValueChanged.AddListener(ToyGunSetRating);
        train.onValueChanged.AddListener(TrainSetRating);
        swordGame.onValueChanged.AddListener(SwordGameSetRating);

        submitAndQuit.onClick.AddListener(OnSubmitAndQuit);
    }
    public void LiveDrawingSetRating(int value)
    {
        int output = value + 1;
        airtableManager.liveDrawingRating = output.ToString();
    }

    public void ToyGunSetRating(int value)
    {
        int output = value + 1;
        airtableManager.toyGunRating = output.ToString();
    }

    public void TrainSetRating(int value)
    {
        int output = value + 1;
        airtableManager.trainRating = output.ToString();
    }

    public void SwordGameSetRating(int value)
    {
        int output = value + 1;
        airtableManager.swordGameRating = output.ToString(); ;
    }

    public void OnSubmitAndQuit() {
        airtableManager.CreateRecord();
        Application.Quit();
    }
}
