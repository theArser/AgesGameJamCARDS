using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenu.MainMenuButtons _buttonType;
    public void buttonClicked()
    {
        MainMenu._.MainMenuButtonClicked(_buttonType);
    }
}
