using UnityEngine;
using UnityEngine.UIElements;

public class MinigameButton : MonoBehaviour
{
    private UIDocument _buttonDocument;
    private Button _uiButton;
    private VisualElement _anotherElement;
    private void Awake()
    {
        _buttonDocument = GetComponent<UIDocument>();
        if (_buttonDocument == null)
        {
            Debug.LogError("UIDocument component not found on GameObject.");
            return;
        }
        _uiButton = _buttonDocument.rootVisualElement.Q<Button>("Minigame");
        if (_uiButton == null)
        {
            Debug.LogError("Button with the name 'Minigame' not found.");
            return;
        }

        _anotherElement = _buttonDocument.rootVisualElement.Q<VisualElement>("Minigame_Window");

        _anotherElement.style.display = DisplayStyle.None;

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
        if (_anotherElement != null)
        {
            _anotherElement.style.display = DisplayStyle.Flex;
        }
    }
}