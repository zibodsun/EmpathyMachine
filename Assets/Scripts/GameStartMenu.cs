using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  Main menu of the application. Sets up the buttons and panels.
 */
public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject form;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button quitButton;

    public GameObject title,panel;
    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(EnableForm);
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

    public void HideAll()
    {
        mainMenu.SetActive(false);
        form.SetActive(false);
        title.SetActive(false);
        panel.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        form.SetActive(false);
    }
}
