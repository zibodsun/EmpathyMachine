using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    public GameObject scene;
    public static bool continuousTurn;

    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject form;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button smoothButton;
    public Button snapButton;
    public Button quitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(EnableForm);
        smoothButton.onClick.AddListener(EnableSmoothTurning);
        snapButton.onClick.AddListener(EnableSnapTurning);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableForm() {
        mainMenu.SetActive(false);
        form.SetActive(true);
    }

    public void StartGame()
    {
        HideAll();
        //SceneTransitionManager.singleton.GoToSceneAsync(1);
        scene.SetActive(true);
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        form.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        form.SetActive(false);
    }
    public void EnableSmoothTurning()
    {
        // 
    }
    public void EnableSnapTurning()
    {
        // 
    }
}
