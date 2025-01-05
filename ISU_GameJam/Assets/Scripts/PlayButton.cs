using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class PlayButton : MonoBehaviour
{
    private UIDocument _buttonDocument;
    private Button _uiButton;
    private Button _anotherButton;
    private VisualElement _imageElement;
    private PlayableDirector _timelineDirector;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _buttonDocument = GetComponent<UIDocument>();
        if (_buttonDocument == null)
        {
            Debug.LogError("UIDocument component not found on GameObject.");
            return;
        }
        _uiButton = _buttonDocument.rootVisualElement.Q<Button>("Play_Button");
        if (_uiButton == null)
        {
            Debug.LogError("Button with the name 'File' not found.");
            return;
        }

        _anotherButton = _buttonDocument.rootVisualElement.Q<Button>("Settings_Button");
        _imageElement = _buttonDocument.rootVisualElement.Q<VisualElement>("Blur");
        _timelineDirector = GameObject.Find("Timeline").GetComponent<PlayableDirector>();

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
        if(evt != null)
        {
            _audioSource.Play();
        }
        if (_timelineDirector != null)
        {
            _timelineDirector.Play();  // This starts the timeline and its animations
        }

        _uiButton.style.display = DisplayStyle.None;
        if (_anotherButton != null)
            _anotherButton.style.display = DisplayStyle.None;
        if (_imageElement != null)
            _imageElement.style.display = DisplayStyle.None;

        StartCoroutine(WaitAndChangeScene(4f));
    }

    private IEnumerator WaitAndChangeScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("gameScreen");
    }
}