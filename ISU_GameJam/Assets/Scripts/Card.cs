using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    public Sprite frontImage;
    private UnityEngine.UI.Image frontImageComponent;
    private UnityEngine.UI.Image backImageComponent;
    private bool isFlipped = false;
    public bool isMatched = false;
    private VisualElement cardElement;

    public MemoryGameManager gameManager; // Reference to the game manager

    void Start()
    {
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

    public void ResetCard()
    {
        isFlipped = false;
        backImageComponent.gameObject.SetActive(true);
        frontImageComponent.gameObject.SetActive(false);
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
