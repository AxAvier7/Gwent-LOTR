using System.Collections;
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
    if(Faccion == "Comunidad del Anillo")
    {
        foreach (GameObject Carta in CartasenFranja)
        {
            Carta.transform.SetParent(GraveyardCDA.transform,false);
            Carta.transform.position = GraveyardCDA.transform.position;
        }
        CartasenFranja.Clear();
    }

if(Faccion == "Mordor")
    {
        foreach (GameObject Carta in CartasenFranja)
        {
            Carta.transform.SetParent(GraveyardMordor.transform,false);
            Carta.transform.position = GraveyardMordor.transform.position;
        }
        CartasenFranja.Clear();
    }}}}