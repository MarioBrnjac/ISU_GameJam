using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadStartScreen()
    {
        SceneManager.LoadScene("startScreen");
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("gameScreen");
    }
    public void LoadPopUpScreen()
    {
        SceneManager.LoadScene("popUpScreen");
    }
}
