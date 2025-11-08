using UnityEngine;

public class OptionsMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenu.OptionsMenuButtons _buttonType;
    public void buttonClicked()
    {
        MainMenu._.OptionsButtonClicked(_buttonType);
    }
}
