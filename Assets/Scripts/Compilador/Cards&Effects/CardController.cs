using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button transferButton;
    public GameObject baseCardObject;
    public GameObject mazoCDAObject;
    public GameObject mazoMordorObject;
    private RobarCDA robarCDA;
    private RobarMordor robarMordor;

    private void Start()
    {
        robarCDA = mazoCDAObject.GetComponent<RobarCDA>();
        robarMordor = mazoMordorObject.GetComponent<RobarMordor>();
        if (transferButton != null)
        {
            transferButton.onClick.AddListener(TransferCardDataToBaseCard);
        }
    }

    public void TransferCardDataToBaseCard()
    {
        CardManager cardManager = CardManager.Instance;
        if (cardManager != null)
        {
            CardData cardData = cardManager.GetLastConfirmedCard();

            if (cardData != null)
            {
                ClaseCarta baseCard = baseCardObject.GetComponent<ClaseCarta>();

                if (baseCard != null)
                {
                    baseCard.Rango = cardData.Type;
                    baseCard.Nombre = cardData.Name;
                    baseCard.Faccion = cardData.Faction;
                    baseCard.Poder = cardData.Power;
                    baseCard.PoderInicial = cardData.OriginalPower;
                    baseCard.Franja = cardData.selectedRange;
                    baseCard.Descripcion = cardData.Description;
                    baseCard.Franjita = cardData.Franjita;
                    baseCard.Habilidad = cardData.Habilidad;
                    baseCard.Afectaumento = cardData.Afectaumento;
                    baseCard.Afectclima = cardData.Afectclima;
                    baseCard.yarepartida = cardData.yarepartida;
                    baseCard.Franja_afectada = cardData.Franja_afectada;
                    baseCard.aragornrend = cardData.aragornrend;
                    baseCard.sauronrend = cardData.sauronrend;
                    baseCard.Turno = cardData.Turno;
                    TransferCardToDeck(baseCard);
                    Debug.Log("Datos transferidos correctamente a BaseCard: " + baseCard.Nombre);
                }
                else
                {
                    Debug.LogError("El objeto no tiene el componente BaseCard.");
                }
            }
            else
            {
                Debug.LogError("No se encontró ninguna carta en el CardManager.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el CardManager.");
        }
    }

    public void TransferCardToDeck(ClaseCarta baseCard)
    {
        if (baseCard.Faccion == "Comunidad del Anillo")
        {
            robarCDA.CDA.Add(baseCardObject);
            Debug.Log("Carta añadida al mazo de la Comunidad del Anillo.");
        }
        else if (baseCard.Faccion == "Mordor")
        {
            baseCard.Turno = false;
            robarMordor.Mordor.Add(baseCardObject); 
            Debug.Log("Carta añadida al mazo de Mordor.");
        }
        else
        {
            Debug.LogWarning("Facción desconocida: " + baseCard.Faccion);
        }
    }
}