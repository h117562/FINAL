using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void LobbyClick()
    {
        GameSceneManager.Instance.SceneSelect(SCENES.LobbyScene);
    }

    public void ChoiceModeClick()
    {
        GameSceneManager.Instance.SceneSelect(SCENES.SelectScene);
    }

    public void RandomModeClick()
    {
        GameSceneManager.Instance.SceneSelect(SCENES.GameChangeScene);
    }

    public void GatchaClick()
    {
        GameSceneManager.Instance.SceneSelect(SCENES.GatchaScene);
    }

    public void OptionClick()
    {
        GameSceneManager.Instance.PopUpSelect(SCENES.OptionScene);
    }

    public void ShopClick()
    {
        GameSceneManager.Instance.PopUpSelect(SCENES.ShopScene);
    }
}