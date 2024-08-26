using System.Collections.Generic;
using UnityEngine;

public class FranjaClima : MonoBehaviour
{
private GameObject CartaJugada;
public List<GameObject> CartasenFranja;
public string Faccion;
private int Ronda = 1;
public GameObject GraveyardCDA;
public GameObject GraveyardMordor;
private int ComprobadordeRonda = 1;

private void OnCollisionEnter2D(Collision2D collision)
{
    CartaJugada = collision.gameObject;
    CartasenFranja.Add(CartaJugada);
}

void Update()
{
    Ronda = GameObject.Find("CalcGanador").GetComponent<Gestordeturnosymastallas>().Ronda;
    if(ComprobadordeRonda != Ronda)
    {
        ComprobadordeRonda = Ronda;
        GameObject destino = (Faccion == "Comunidad del Anillo") ? GraveyardCDA : GraveyardMordor;
        foreach (GameObject carta in CartasenFranja)
        {
            carta.transform.SetParent(destino.transform, false);
            carta.transform.position = destino.transform.position;
        }
        CartasenFranja.Clear();
    }
}
}