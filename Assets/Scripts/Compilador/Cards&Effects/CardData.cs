using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    public string Type;
    public string Name;
    public string Faction;
    public int Power;
    public int OriginalPower;
    public string selectedRange;
    public string Description;
    public int Franjita;
    public Sprite CardImage;
    public string Habilidad;
    public bool Afectaumento;
    public bool Afectclima;
    public string Franja_afectada;
    public bool aragornrend;
    public bool sauronrend;
    public bool Turno;
    public bool yarepartida;
    public List<Effect> Effects { get; set; }
    public int Amount { get; set; }
}