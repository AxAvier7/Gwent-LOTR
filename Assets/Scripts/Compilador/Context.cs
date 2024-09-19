using System;
using System.Collections.Generic;
using System.Linq;

public class Card
{
    public int Owner { get; set; }
    public int Power { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Faction { get; set; }
    public string Range { get; set; }
}

public class Context
{
    private int triggerPlayerId;
    private Dictionary<int, List<Card>> hands;
    private Dictionary<int, List<Card>> fields;
    private Dictionary<int, List<Card>> graveyards;
    private Dictionary<int, List<Card>> decks;
    private List<Card> board;

    public Context(int triggerPlayerId)
    {
        this.triggerPlayerId = triggerPlayerId;
        this.hands = new Dictionary<int, List<Card>>();
        this.fields = new Dictionary<int, List<Card>>();
        this.graveyards = new Dictionary<int, List<Card>>();
        this.decks = new Dictionary<int, List<Card>>();
        this.board = new List<Card>();
    }

    public int TriggerPlayer => triggerPlayerId;

    public List<Card> Board => board;

    public List<Card> HandOfPlayer(int playerId)
    {
        if (!hands.ContainsKey(playerId)) 
            return new List<Card>();
        return new List<Card>(hands[playerId]);
    }

    public List<Card> FieldOfPlayer(int playerId)
    {
        if (!fields.ContainsKey(playerId)) 
            return new List<Card>();
        return new List<Card>(fields[playerId]);
    }

    public List<Card> GraveyardOfPlayer(int playerId)
    {
        if (!graveyards.ContainsKey(playerId)) 
            return new List<Card>();
        return new List<Card>(graveyards[playerId]);
    }

    public List<Card> DeckOfPlayer(int playerId)
    {
        if (!decks.ContainsKey(playerId)) 
            return new List<Card>();
        return new List<Card>(decks[playerId]);
    }

    // Propiedades simplificadas para el jugador que desencadenó el efecto
    public List<Card> Hand => HandOfPlayer(TriggerPlayer);
    public List<Card> Field => FieldOfPlayer(TriggerPlayer);
    public List<Card> Graveyard => GraveyardOfPlayer(TriggerPlayer);
    public List<Card> Deck => DeckOfPlayer(TriggerPlayer);

    // Métodos para agregar cartas a las colecciones del contexto
    public void AddCardToHand(int playerId, Card card)
    {
        if (!hands.ContainsKey(playerId))
        {
            hands[playerId] = new List<Card>();
        }
        hands[playerId].Add(card);
    }

    public void AddCardToField(int playerId, Card card)
    {
        if (!fields.ContainsKey(playerId))
        {
            fields[playerId] = new List<Card>();
        }
        fields[playerId].Add(card);
    }

    public void AddCardToGraveyard(int playerId, Card card)
    {
        if (!graveyards.ContainsKey(playerId))
        {
            graveyards[playerId] = new List<Card>();
        }
        graveyards[playerId].Add(card);
    }

    public void AddCardToDeck(int playerId, Card card)
    {
        if (!decks.ContainsKey(playerId))
        {
            decks[playerId] = new List<Card>();
        }
        decks[playerId].Add(card);
    }

    public void AddCardToBoard(Card card)
    {
        board.Add(card);
    }

    public void RemoveCardFromHand(int playerId, Card card)
    {
        if (hands.ContainsKey(playerId))
        {
            hands[playerId].Remove(card);
        }
    }

    public void RemoveCardFromField(int playerId, Card card)
    {
        if (fields.ContainsKey(playerId))
        {
            fields[playerId].Remove(card);
        }
    }

    public void RemoveCardFromGraveyard(int playerId, Card card)
    {
        if (graveyards.ContainsKey(playerId))
        {
            graveyards[playerId].Remove(card);
        }
    }

    public void RemoveCardFromDeck(int playerId, Card card)
    {
        if (decks.ContainsKey(playerId))
        {
            decks[playerId].Remove(card);
        }
    }

    public void RemoveCardFromBoard(Card card)
    {
        board.Remove(card);
    }

    #region MetodosContext
    public List<Card> Find(Func<Card, bool> predicate)
    {
        return Hand.Concat(Field).Concat(Graveyard).Concat(Deck).Concat(Board)
            .Where(predicate)
            .ToList();
    }

    public void Push(Card card)
    {
        Hand.Insert(0, card);
    }

    public void SendBottom(Card card)
    {
        Hand.Add(card);
    }

    public Card Pop()
    {
        if (Hand.Count > 0)
        {
            Card card = Hand[0];
            Hand.RemoveAt(0);
            return card;
        }
        throw new InvalidOperationException("No hay cartas en la mano para quitar.");
    }

    public void Shuffle()
    {
        Random rng = new Random();
        List<Card> cards = Hand.ToList();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
        Hand.Clear();
        Hand.AddRange(cards);
    }
}
    #endregion MetodosContext