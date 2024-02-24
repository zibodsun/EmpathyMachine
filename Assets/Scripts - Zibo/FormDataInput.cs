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

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        sceneTransitionManager.GetComponent<Animator>().Play("PulseToBlack");
    }
}
