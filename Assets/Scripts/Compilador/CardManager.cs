using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<GameObject> cartasGuardadas = new List<GameObject>();
    public Button guardarCartaButton;
    public GameObject cardPrototypeObject;
    
    private static CardManager instance;

    public static CardManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CardManager>();
                if (instance == null)
                {
                    GameObject cardManagerObject = new GameObject("CardManager");
                    instance = cardManagerObject.AddComponent<CardManager>();
                    Debug.Log("Se creó un nuevo CardManager.");
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
        if (guardarCartaButton != null)
        {
            guardarCartaButton.onClick.AddListener(GuardarCarta);
        }
        else
        {
            Debug.LogError("No se ha asignado un botón para guardar la carta.");
        }
    }

    public void GuardarCarta()
    {
        if (cardPrototypeObject != null)
        {
            BaseCard cardPrototype = cardPrototypeObject.GetComponent<BaseCard>();

            if (cardPrototype != null)
            {
                GameObject nuevaCarta = CrearNuevaCarta(cardPrototype);
                if (nuevaCarta != null)
                {
                    AddCard(nuevaCarta);
                    Debug.Log("Carta guardada tras declarar parámetros.");
                }
            }
            else
            {
                Debug.LogError("No se encontró el componente BaseCard en el objeto cardPrototypeObject.");
            }
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto que contiene el prototipo de la carta.");
        }
    }

    private GameObject CrearNuevaCarta(BaseCard cardPrototype)
    {
        GameObject carta = new GameObject("Nueva Carta");

        BaseCard baseCard = carta.AddComponent<BaseCard>();
        baseCard.Name = cardPrototype.Name;
        baseCard.Faction = cardPrototype.Faction;
        baseCard.Type = cardPrototype.Type;
        baseCard.Power = cardPrototype.Power;
        baseCard.Range = new List<string>(cardPrototype.Range);
        baseCard.Description = cardPrototype.Description;
        baseCard.Franjita = cardPrototype.Franjita;

        return carta;
    }

    public void AddCard(GameObject card)
    {
        if (cartasGuardadas == null)
        {
            cartasGuardadas = new List<GameObject>();
            Debug.Log("Inicializada cartasGuardadas.");
        }

        if (card != null)
        {
            if (!cartasGuardadas.Contains(card))
            {
                cartasGuardadas.Add(card);
                Debug.Log("Carta añadida a cartasGuardadas.");
            }
        }
        else
        {
            Debug.LogWarning("Intento de añadir una carta nula.");
        }
    }

    public void TransferCardsToDecks()
    {
        RobarCDA robarCDA = FindObjectOfType<RobarCDA>();
        RobarMordor robarMordor = FindObjectOfType<RobarMordor>();

        if (cartasGuardadas != null)
        {
            foreach (var card in cartasGuardadas)
            {
                if (card != null)
                {
                    BaseCard baseCard = card.GetComponent<BaseCard>();
                    if (baseCard != null)
                    {
                        if (baseCard.Faction == "Comunidad del Anillo" && robarCDA != null)
                        {
                            robarCDA.CDA.Add(card);
                            Debug.Log("Carta añadida al mazo de la Comunidad del Anillo.");
                        }
                        else if (baseCard.Faction == "Mordor" && robarMordor != null)
                        {
                            robarMordor.Mordor.Add(card);
                            Debug.Log("Carta añadida al mazo de Mordor.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("La carta no tiene componente BaseCard.");
                    }
                }
                else
                {
                    Debug.LogWarning("Carta nula encontrada en cartasGuardadas.");
                }
            }
        }
        else
        {
            Debug.LogError("No hay cartas guardadas.");
        }
    }

    public List<GameObject> GetCartasGuardadas()
    {
        return cartasGuardadas;
    }
}