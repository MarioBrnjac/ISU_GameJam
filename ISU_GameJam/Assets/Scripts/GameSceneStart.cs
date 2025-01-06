using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameSceneStart : MonoBehaviour
{
    private UIDocument _buttonDocument;
    private Button _uiButton;

    private void Awake()
    {
        _buttonDocument = GetComponent<UIDocument>();

        _uiButton = _buttonDocument.rootVisualElement.Q<Button>("Close");

        _uiButton.RegisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnDisable()
    {
        if (_uiButton != null)
        {
            _uiButton.UnregisterCallback<ClickEvent>(OnPlayGameClick);
        }
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        SceneManager.LoadScene("gameScreen");
    }

}
