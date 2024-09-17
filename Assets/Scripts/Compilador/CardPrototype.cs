using UnityEngine;
using System.Collections.Generic;

public class BaseCard : MonoBehaviour
{
    public string Type;
    public string Name;
    public string Faction;
    public int Power;
    public List<string> Range;
    public string Description;
    private string selectedRange;
    private bool isFrangeChosen = false;
    public int Franjita;
    public Sprite CardImage;
    private bool cartaCreada = false;

    void Update()
    {
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
            cardManager.AddCard(gameObject);
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