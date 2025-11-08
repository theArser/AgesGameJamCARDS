using UnityEngine;

public class CreditsMenuButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] MainMenu.CreditsMenuButtons _buttonType;
    public void buttonClicked()
    {
        MainMenu._.CreditsButtonClicked(_buttonType);
    }
}
