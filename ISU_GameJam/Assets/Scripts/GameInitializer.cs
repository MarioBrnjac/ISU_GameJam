using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public UIManager uiManager;

    void Update()
    {
        if (Input.anyKey)
        {
            uiManager.LoadStartScreen();
        }
        if (Input.anyKey)
        {
            uiManager.LoadGameScreen();
        }
    }
}
