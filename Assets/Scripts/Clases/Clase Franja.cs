using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClaseFranja : MonoBehaviour
{
private GameObject CartaJugada;
public GameObject playedcard; //cartagutts
public List<GameObject> CartasenFranja;
public int Suma = 0;
public int Cartas = 0;
public Text puntuationText;
public string Faccion;
public int franja;
public GameObject GraveyardCDA;
public GameObject GraveyardMordor;
public GameObject ManoPlayer;
public GameObject ManoVS;
public int sumaparcial = 0;
public bool climaafectado = false;
public bool aumentoafectado = false;


private ClaseFranja Mprop; //pcc
private ClaseFranja Rprop; //pd
private ClaseFranja Sprop; //ps
private ClaseFranja Mvs; //ecc
private ClaseFranja Rvs; //ed
private ClaseFranja Svs; //es


private int Ronda = 1;
private int ComprobadordeRonda = 1;


private void OnCollisionEnter2D(Collision2D collision)
{
CartaJugada = collision.gameObject;
CartasenFranja.Add(CartaJugada);
Cartas += 1;
}


public void Cuerno()
    {
       aumentoafectado = true;  
    }

public void Anillo()
    {
       aumentoafectado = true;  
    }

public void Despeje()
    {
        climaafectado = false;
        foreach(GameObject Card in CartasenFranja)
        {
            Card.GetComponent<ClaseCarta>().Afectclima = false;
            Card.GetComponent<ClaseCarta>().Afectaumento = false;
            Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial;
        }
    }


void Update()
{
ManoPlayer = GameObject.Find("manojugador");
ManoVS = GameObject.Find("manomordor");
Mprop = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
Rprop = GameObject.FindGameObjectWithTag("CDADistance").GetComponent<ClaseFranja>(); 
Sprop = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
Mvs = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
Rvs = GameObject.FindGameObjectWithTag("MordorDistance").GetComponent<ClaseFranja>(); 
Svs = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();  

if(ComprobadordeRonda != Ronda)
        {
            ComprobadordeRonda = Ronda;
            if(Faccion == "Sacrificios")
            {
                foreach(GameObject Card in CartasenFranja)
                {
                    Card.transform.SetParent(GraveyardCDA.transform, true);
                    Card.transform.position = GraveyardCDA.transform.position;
                }
                CartasenFranja.Clear();
                 Suma = 0;
                puntuationText.text = Suma.ToString();
            }

             if(Faccion == "Mordor")
            {
                foreach(GameObject Card in CartasenFranja)
                {
                    Card.transform.SetParent(GraveyardMordor.transform, true);
                    Card.transform.position = GraveyardMordor.transform.position;
                }
                CartasenFranja.Clear();
                Suma = 0;
                puntuationText.text = Suma.ToString();
            }
            Mprop.aumentoafectado = false;
            Mprop.climaafectado = false;
            Rprop.aumentoafectado = false;
            Rprop.climaafectado = false;
            Sprop.aumentoafectado = false;
            Sprop.climaafectado = false;
            Mvs.aumentoafectado = false;
            Mvs.climaafectado = false;
            Rvs.aumentoafectado = false;
            Rvs.climaafectado = false;
            Svs.aumentoafectado = false;
            Svs.climaafectado = false;
        }

sumaparcial = 0;
for(int i = 0; i < CartasenFranja.Count; i++)
{
sumaparcial += CartasenFranja[i].GetComponent<ClaseCarta>().Poder;
}
Suma = sumaparcial;
puntuationText.text = Suma.ToString();


if(aumentoafectado)
        {
            foreach(GameObject Card in CartasenFranja)
          {
            if(Card.GetComponent<ClaseCarta>().Rango != "Oro" && Card.GetComponent<ClaseCarta>().Afectaumento == false) //si no es de oro y no esta afectada le suma 1
            {
                Card.GetComponent<ClaseCarta>().Afectaumento = true;
                Card.GetComponent<ClaseCarta>().Poder += 1;
            }
          }
        }

if(climaafectado)
        {
            foreach(GameObject Card in CartasenFranja)
          {
            if(Card.GetComponent<ClaseCarta>().Rango != "oro" && Card.GetComponent<ClaseCarta>().Afectclima == false) // si no es de oro y no esta afectada ya la vuelve 1
            {
                Card.GetComponent<ClaseCarta>().Afectclima = true;
                Card.GetComponent<ClaseCarta>().Poder = 1;
            }
          }
        }
}
}