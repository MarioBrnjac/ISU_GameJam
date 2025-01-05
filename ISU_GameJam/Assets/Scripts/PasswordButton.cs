using UnityEngine;
using UnityEngine.UIElements;

public class PasswordButton : MonoBehaviour
{
    private UIDocument _buttonDocument;
    private Button _uiButton;
    private void Awake()
    {
        _buttonDocument = GetComponent<UIDocument>();
        if (_buttonDocument == null)
        {
            Debug.LogError("UIDocument component not found on GameObject.");
            return;
        }
        _uiButton = _buttonDocument.rootVisualElement.Q<Button>("Password");
        if (_uiButton == null)
        {
            Debug.LogError("Button with the name 'File' not found.");
            return;
        }
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
        Debug.Log("Hello World");
    }
}
