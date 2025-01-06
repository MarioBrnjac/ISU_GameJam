using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class MemoryGameManager : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab for the card GameObject
    public VisualTreeAsset cardTemplate; // UXML template for the card
    public UIDocument uiDocument; // Reference to the UIDocument
    public List<Sprite> cardFrontImages; // List of front images for the cards

    private VisualElement cardContainer; // Container to hold the card VisualElements
    private List<Card> allCards = new List<Card>();
    private Card firstCard, secondCard;
    private bool isChecking;

    void Start()
    {
        var root = uiDocument.rootVisualElement;
        cardContainer = root.Q<VisualElement>("CardContainer"); // Reference to the card container

        SetupCards();
    }

    void SetupCards()
    {
        // Create pairs of cards
        int numPairs = cardFrontImages.Count;

        for (int i = 0; i < numPairs; i++)
        {
            // Create two cards for each pair
            CreateCard(i);
            CreateCard(i);
        }

        // Shuffle the cards
        ShuffleCards();
    }

    void CreateCard(int index)
    {
        // Instantiate the prefab
        GameObject cardObject = Instantiate(cardPrefab);
        Card card = cardObject.GetComponent<Card>();
        card.frontImage = cardFrontImages[index];
        card.gameManager = this;

        // Create VisualElement from the UXML template
        VisualElement cardElement = cardTemplate.CloneTree();
        cardElement.Q<Button>("card-button").clicked += card.OnCardClicked;
        cardElement.Q<Image>("card-back").sprite = card.frontImage;
        cardElement.Q<Image>("card-front").sprite = card.frontImage;

        // Add the VisualElement to the container
        cardContainer.Add(cardElement);

        // Link the Card script to the VisualElement
        card.SetVisualElement(cardElement);

        allCards.Add(card);
    }

    void ShuffleCards()
    {
        System.Random rng = new System.Random();
        int n = allCards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = allCards[k];
            allCards[k] = allCards[n];
            allCards[n] = temp;
        }
    }

    public void OnCardFlipped(Card flippedCard)
    {
        if (isChecking) return;

        if (firstCard == null)
        {
            firstCard = flippedCard;
        }
        else
        {
            secondCard = flippedCard;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        isChecking = true;
        yield return new WaitForSeconds(1);

        if (firstCard.GetFrontImage() == secondCard.GetFrontImage()) // Check if cards match
        {
            Debug.Log("Match found!");
            firstCard.SetMatched();
            secondCard.SetMatched();

            // Shuffle remaining unmatched cards
            ShuffleUnmatchedCards();
        }
        else
        {
            Debug.Log("No match!");
            firstCard.ResetCard();
            secondCard.ResetCard();
        }

        firstCard = null;
        secondCard = null;
        isChecking = false;
    }

    void ShuffleUnmatchedCards()
    {
        List<Card> unmatchedCards = allCards.FindAll(card => !card.isMatched);
        System.Random rng = new System.Random();
        int n = unmatchedCards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = unmatchedCards[k];
            unmatchedCards[k] = unmatchedCards[n];
            unmatchedCards[n] = temp;
        }

        // Reposition cards after shuffling
        for (int i = 0; i < unmatchedCards.Count; i++)
        {
            GameObject cardObject = unmatchedCards[i].gameObject;
            cardObject.transform.localPosition = new Vector3((i % 4) * 100, -(i / 4) * 150, 0); // Example positioning
        }
    }
}
