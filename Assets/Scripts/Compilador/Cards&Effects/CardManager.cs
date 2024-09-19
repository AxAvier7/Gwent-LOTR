using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    public List<CardData> cardList = new List<CardData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCardData(CardData cardData)
    {
        cardList.Add(cardData);
        Debug.Log("Carta añadida al CardManager: " + cardData.Name);
    }

    public List<CardData> GetAllCards()
    {
        return cardList;
    }
    public CardData GetLastConfirmedCard()
    {
        if (cardList.Count > 0)
        {
            return cardList[cardList.Count - 1];
        }
        else
        {
            Debug.LogWarning("No hay cartas en la lista.");
            return null;
        }
    }
}
