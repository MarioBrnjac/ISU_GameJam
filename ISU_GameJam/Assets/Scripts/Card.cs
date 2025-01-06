using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    public Sprite frontImage;
    private UnityEngine.UI.Image frontImageComponent; // UnityEngine.UI.Image
    private UnityEngine.UI.Image backImageComponent;  // UnityEngine.UI.Image
    private VisualElement cardElement; // UnityEngine.UIElements.VisualElement
    private VisualElement frontImageElement;
    private VisualElement backImageElement;
    private bool isFlipped = false;
    public bool isMatched = false;

    public MemoryGameManager gameManager; // Reference to the game manager

    void Start()
    {
        // Unity UI Setup
        frontImageComponent = transform.Find("FrontImage").GetComponent<UnityEngine.UI.Image>();
        backImageComponent = transform.Find("BackImage").GetComponent<UnityEngine.UI.Image>();

        if (frontImageComponent != null)
        {
            frontImageComponent.sprite = frontImage;
            frontImageComponent.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("FrontImage component not found.");
        }

        if (backImageComponent != null)
        {
            backImageComponent.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("BackImage component not found.");
        }

        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnCardClicked);
        }
        else
        {
            Debug.LogError("Button component not found.");
        }

        // UI Toolkit Setup
        VisualElement rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        cardElement = rootVisualElement.Q<VisualElement>("card");

        frontImageElement = cardElement.Q<VisualElement>("card-front");
        backImageElement = cardElement.Q<VisualElement>("card-back");

        frontImageElement.style.backgroundImage = new StyleBackground(frontImage);

        cardElement.RegisterCallback<ClickEvent>(evt => OnCardClickedUIElements());
    }

    public void OnCardClicked()
    {
        if (isFlipped || isMatched) return;

        isFlipped = true;
        backImageComponent.gameObject.SetActive(false);
        frontImageComponent.gameObject.SetActive(true);

        // Notify the game manager about the flip
        if (gameManager != null)
        {
            gameManager.OnCardFlipped(this);
        }
        else
        {
            Debug.LogError("GameManager reference not set.");
        }
    }

    public void OnCardClickedUIElements()
    {
        if (isFlipped || isMatched) return;

        isFlipped = true;
        backImageElement.RemoveFromClassList("show");
        frontImageElement.AddToClassList("show");

        // Notify the game manager about the flip
        if (gameManager != null)
        {
            gameManager.OnCardFlipped(this);
        }
        else
        {
            Debug.LogError("GameManager reference not set.");
        }
    }

    public void ResetCard()
    {
        isFlipped = false;
        backImageComponent.gameObject.SetActive(true);
        frontImageComponent.gameObject.SetActive(false);

        backImageElement.AddToClassList("show");
        frontImageElement.RemoveFromClassList("show");
    }

    public Sprite GetFrontImage()
    {
        return frontImage;
    }

    public void SetMatched()
    {
        isMatched = true;
    }

    public void SetVisualElement(VisualElement element)
    {
        cardElement = element;
    }
}
