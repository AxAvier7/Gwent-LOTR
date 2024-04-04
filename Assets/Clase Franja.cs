using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaseFranja : MonoBehaviour
{
private GameObject CartaJugada;
public GameObject playedcard;
public List<GameObject> CartasenFranja;
public int Suma=0;
public Text puntuationText;
public string Faccion;
public int franja;
public GameObject GraveyardCDA;
public GameObject GraveyardMordor;
public GameObject ManoPlayer;
public GameObject ManoVS;
public int sumaparcial;

private void OnCollisionEnter2D(Collision2D collision)
{
CartaJugada = collision.gameObject;
CartasenFranja.Add(CartaJugada);
}

void Update()
{
sumaparcial = 0;
for(int i = 0; i < CartasenFranja.Count; i++)
{
sumaparcial += CartasenFranja[i].GetComponent<ClaseCarta>().Poder;
}
Suma = sumaparcial;
puntuationText.text = Suma.ToString();
}
}
