using UnityEngine;
using System.Collections.Generic;

public class BaseCard : MonoBehaviour
{
    public string Type;
    public string Name;
    public string Faction;
    public int Power;
    public int OriginalPower;
    public List<string> Range;
    public string Description;
    public string selectedRange;
    private bool isFrangeChosen = false;
    public int Franjita;
    public Sprite CardImage;
    private bool cartaCreada = false;

    public string Habilidad;
    public bool Afectaumento = false;
    public bool Afectclima = false;
    public bool yarepartida = false;
    public string Franja_afectada;
    public bool aragornrend;
    public bool sauronrend;
    public bool Turno = true;

    void Update()
    {
        OriginalPower = Power;
        if (!cartaCreada)
        {
            GuardarCarta();
            cartaCreada = true;
        }

        if (Range != null && Range.Count >0 && isFrangeChosen == false)
        {
            selectedRange = Range[Random.Range(0, Range.Count)];
            isFrangeChosen = true;
        }
        if(Faction == "CDA") Faction = "Comunidad del Anillo";
        if ((Faction == "Comunidad del Anillo" || Faction == "Mordor") && (Type == "Oro" || Type == "Plata"))
        {
            if (selectedRange == "Melee")
                Franjita = 1;
            else if (selectedRange == "Ranged")
                Franjita = 2;
            else if (selectedRange == "Siege")
                Franjita = 3;
        }
        if (Type == "Aumento" || Type == "Clima")
        {
            if (selectedRange == "Melee")
                Franjita = 4;
            else if (selectedRange == "Ranged")
                Franjita = 5;
            else if (selectedRange == "Siege")
                Franjita = 6;
            Power = 0;
        }
    }

    private void GuardarCarta()
    {
        CardManager cardManager = CardManager.Instance;
        if (cardManager != null)
        {
            CardData newCardData = new CardData
            {
                Type = this.Type,
                Name = this.Name,
                Faction = this.Faction,
                Power = this.Power,
                OriginalPower = this.OriginalPower,
                selectedRange = this.selectedRange,
                Description = this.Description,
                Franjita = this.Franjita,
                CardImage = this.CardImage,

                Habilidad = this.Habilidad,
                Afectaumento = this.Afectaumento,
                Afectclima = this.Afectclima,
                yarepartida = this.yarepartida,
                Franja_afectada = this.Franja_afectada,
                aragornrend = this.aragornrend,
                sauronrend = this.sauronrend,
                Turno = this.Turno
            };
        }
        else
        {
            Debug.LogError("CardManager no encontrado en la escena.");
        }    
    }

    public void SetCardImage(Sprite image)
    {
        CardImage = image;
    }
}