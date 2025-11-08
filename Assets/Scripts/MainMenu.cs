using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu _;
    [SerializeField] private bool _debugMode;
    public enum MainMenuButtons { play, options, credits, quit };
    public enum OptionsMenuButtons { back, };
    public enum CreditsMenuButtons { back, };
    [SerializeField] GameObject _mainMenuContainer;
    [SerializeField] GameObject _optionsMenuContainer;
    [SerializeField] GameObject _creditsMenuContainer;
    [SerializeField] private string _sceneToLoadAtClick;

    public void Awake()
    {
        if (_ == null)
        {
            _ = this;
        }
        else
        {
            Debug.LogError("There's more than one MainMenu.cs in the scene");
        }
    }
    public void Start()
    {
        OpenMenu(_mainMenuContainer);
    }
    public void MainMenuButtonClicked(MainMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked " + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case MainMenuButtons.play:
                PlayClicked();
                break;
            case MainMenuButtons.options:
                OpenMenu(_optionsMenuContainer);
                break;
            case MainMenuButtons.credits:
                OpenMenu(_creditsMenuContainer);
                break;
            case MainMenuButtons.quit:
                QuitGame();
                break;
            default:
                Debug.Log("Button clicked but no function assigned");
                break;

        }
    }
    public void OptionsButtonClicked(OptionsMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked " + buttonClicked.ToString());
        switch (buttonClicked)
        {

            case OptionsMenuButtons.back:
                OpenMenu(_mainMenuContainer);
                break;
            default:
                Debug.Log("Button clicked but no function assigned");
                break;
        }
    }
    public void CreditsButtonClicked(CreditsMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked " + buttonClicked.ToString());
        switch (buttonClicked)
        {

            case CreditsMenuButtons.back:
                OpenMenu(_mainMenuContainer);
                break;
            default:
                Debug.Log("Button clicked but no function assigned");
                break;
        }
    }
    public void PlayClicked()
    {
        //SceneManager.LoadScene(_sceneToLoadAtClick);
    }

    private void DebugMessage(string message)
    {
        Debug.Log(message);
    }
    private void OpenMenu(GameObject menuToOpen)
    {
        _mainMenuContainer.SetActive(menuToOpen == _mainMenuContainer);
        _optionsMenuContainer.SetActive(menuToOpen == _optionsMenuContainer);
        _creditsMenuContainer.SetActive(menuToOpen == _creditsMenuContainer);
    }
    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
    #else
    Application.Quit();
    #endif
    }

}
