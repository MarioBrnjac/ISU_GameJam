using UnityEngine;

public class UIManagerSingleton : MonoBehaviour
{
    public static UIManagerSingleton Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public GameObject startScreen;
    public GameObject popUpScreen;

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
        popUpScreen.SetActive(false);
    }

    public void ShowPopUpScreen()
    {
        startScreen.SetActive(false);
        popUpScreen.SetActive(true);
    }
}
