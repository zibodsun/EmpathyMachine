using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormDataInput : MonoBehaviour
{
    public Button startButton;
    public GameObject scene;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        scene.SetActive(true);
        SceneManager.LoadScene("BedroomScene Zibo");
    }
}
