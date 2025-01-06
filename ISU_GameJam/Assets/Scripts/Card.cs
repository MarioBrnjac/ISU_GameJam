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
        frontImageComponent.sprite = frontImage;
        frontImageComponent.gameObject.SetActive(false);
        backImageComponent.gameObject.SetActive(true);

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnCardClicked);
    }

    public void OnCardClicked()
    {
        if (isFlipped || isMatched) return;
        isFlipped = true;
        backImageComponent.gameObject.SetActive(false);
        frontImageComponent.gameObject.SetActive(true);

        cardElement.Q<UnityEngine.UIElements.Image>("card-back").style.display = DisplayStyle.None;

        // Notify the game manager about the flip
        gameManager.OnCardFlipped(this);
    }

    public void ResetCard()
    {
        isFlipped = false;
        backImageComponent.gameObject.SetActive(true);
        frontImageComponent.gameObject.SetActive(false);

        cardElement.Q<UnityEngine.UIElements.Image>("card-back").style.display = DisplayStyle.Flex;
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

    }
}
