using UnityEngine;

public class CardCreator : MonoBehaviour
{
    public BaseCard cardToConfirm;

    public void ConfirmarCarta()
    {
        CardManager cardManager = CardManager.Instance;

        if (cardManager != null)
        {
            CardData newCardData = new CardData
            {
                Type = cardToConfirm.Type,
                Name = cardToConfirm.Name,
                Faction = cardToConfirm.Faction,
                Power = cardToConfirm.Power,
                OriginalPower = cardToConfirm.OriginalPower,
                selectedRange = cardToConfirm.selectedRange,
                Description = cardToConfirm.Description,
                Franjita = cardToConfirm.Franjita,
                CardImage = cardToConfirm.CardImage,

                Habilidad = cardToConfirm.Habilidad,
                Afectaumento = cardToConfirm.Afectaumento,
                Afectclima = cardToConfirm.Afectclima,
                yarepartida = cardToConfirm.yarepartida,
                Franja_afectada = cardToConfirm.Franja_afectada,
                aragornrend = cardToConfirm.aragornrend,
                sauronrend = cardToConfirm.sauronrend,
                Turno = cardToConfirm.Turno
            };

            cardManager.AddCardData(newCardData);
            Debug.Log("Carta confirmada y guardada en el CardManager.");
        }
        else
        {
            Debug.LogError("CardManager no encontrado.");
        }
    }
}
