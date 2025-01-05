using UnityEngine;
using UnityEngine.UIElements;

public class PasswordCloseButton : MonoBehaviour
{
    private UIDocument _buttonDocument;
    private Button _uiButton;
    private VisualElement _elementToHide;
    private void Awake()
    {
        _buttonDocument = GetComponent<UIDocument>();
        if (_buttonDocument == null)
        {
            Debug.LogError("UIDocument component not found on GameObject.");
            return;
        }
        _uiButton = _buttonDocument.rootVisualElement.Q<Button>("PasswordCloseButton");
        if (_uiButton == null)
        {
            Debug.LogError("Button with the name 'CloseButton' not found.");
            return;
        }

        _uiButton = _buttonDocument.rootVisualElement.Q<Button>("PasswordCloseButton");

        _elementToHide = _buttonDocument.rootVisualElement.Q<VisualElement>("Password_Window");

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
        if (_elementToHide != null)
        {
            _elementToHide.style.display = DisplayStyle.None;
        }
    }
}
