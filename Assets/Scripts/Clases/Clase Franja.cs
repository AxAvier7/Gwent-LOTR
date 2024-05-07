using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClaseFranja : MonoBehaviour
{
private GameObject CartaJugada;
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
private ClaseFranja Mvs; //ec
private ClaseFranja Rvs;
private ClaseFranja Svs;


private int Ronda = 1;
private int ComprobadordeRonda = 1;


private void OnCollisionEnter2D(Collision2D collision)
{
CartaJugada = collision.gameObject;
CartasenFranja.Add(CartaJugada);
Cartas += 1;
}

//el metodo Sauron funcionaba pero no era exactamente el efecto que se pedia en la orden del proyecto, por eso lo cambie a ultima hora
// public void Sauron()
// {
//     if(Faccion == "Comunidad del Anillo")
//     {
//         if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
//             {
//             int mayor = CartasenFranja[0].GetComponent<ClaseCarta>().Poder;
//             for(int i = 0; i < CartasenFranja.Count; i++)//busca la cartas con mas poder del tablero rival
//             {
//                 mayor = Mathf.Max(mayor, CartasenFranja[i].GetComponent<ClaseCarta>().Poder);
//             }
            
//             foreach(GameObject Cartas in CartasenFranja)
//             {
//                 if(Cartas.GetComponent<ClaseCarta>().Poder == mayor)//manda la carta mas fuerte al cementerio
//                 {
//                     Cartas.transform.SetParent(GraveyardCDA.transform, true);
//                     Cartas.transform.position = GraveyardCDA.transform.position;
//                     CartasenFranja.Remove(Cartas);
//                     break;
//                 }
//             }
//             }
//     }
// }

    public int MayorCarta()
    {
        int mayor = 0;
        foreach(GameObject Card in CartasenFranja)
        {
            mayor = Mathf.Max(mayor, Card.GetComponent<ClaseCarta>().Poder);
        }
        return mayor;
    }

    public void EliminarMayorCarta(int puntos)
    {
        if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
        {
            foreach(GameObject Card in CartasenFranja)
            {
                if(Card.GetComponent<ClaseCarta>().Poder == puntos && Faccion == "Comunidad del Anillo")
                {
                    Card.transform.position = GraveyardCDA.transform.position;
                    Card.transform.SetParent(GraveyardCDA.transform, true);
                    CartasenFranja.Remove(Card);
                    return;
                }
            }
        }
    }


public void Legolas()
{
    if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
        {
            int cartamenor = CartasenFranja[0].GetComponent<ClaseCarta>().Poder;
            for(int i = 0; i < CartasenFranja.Count; i++)
            {
                cartamenor = Mathf.Min(cartamenor, CartasenFranja[i].GetComponent<ClaseCarta>().Poder);
            }
            foreach(GameObject Card in CartasenFranja)
            {
            if(Card.GetComponent<ClaseCarta>().Poder == cartamenor)
            {
                Card.transform.position = GraveyardMordor.transform.position;
                Card.transform.SetParent(GraveyardMordor.transform, true);
                CartasenFranja.Remove(Card);
                break;
            }
            }
        }
}

public int Gandalf()
{
    int promediocartas = 0;
    foreach(GameObject Card in CartasenFranja)
    {
        promediocartas += Card.GetComponent<ClaseCarta>().Poder;
    }
    return promediocartas;
}

public void GandalfUsado(int promediocartas)
{
    foreach(GameObject Card in CartasenFranja)
    {
        Card.GetComponent<ClaseCarta>().Poder = promediocartas;
    }

}

public void Gollum()
{
    if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
    {
    int mayor = CartasenFranja[0].GetComponent<ClaseCarta>().Poder;
    for(int i = 0; i < CartasenFranja.Count; i++)
    {
        mayor = Mathf.Max(mayor, CartasenFranja[i].GetComponent<ClaseCarta>().Poder);
    }
    foreach(GameObject Card in CartasenFranja)
    {
         if(Card.GetComponent<ClaseCarta>().Poder == mayor && Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
        {
            Card.transform.SetParent(ManoPlayer.transform, false);
            Card.transform.position = ManoPlayer.transform.position;
            Card.GetComponent<JugarCarta>().jugable = true;
            Card.GetComponent<ClaseCarta>().Afectclima = false;
            Card.GetComponent<ClaseCarta>().Afectaumento = false;
            Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial;
            CartasenFranja.Remove(Card);
            return;
        }
        if(Card.GetComponent<ClaseCarta>().Poder == mayor && Card.GetComponent<ClaseCarta>().Faccion == "Mordor")
        {
            Card.transform.SetParent(ManoVS.transform, false);
            Card.transform.position = ManoVS.transform.position;
            Card.GetComponent<JugarCarta>().jugable = true;
            Card.GetComponent<ClaseCarta>().Afectclima = false;
            Card.GetComponent<ClaseCarta>().Afectaumento = false;
            Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial;
            CartasenFranja.Remove(Card);
            return;
        }
    }
    }
}


public void Balrog(int Franja)
{
        if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
        {
            if(CartasenFranja.Count < 10)
            {
                if(CartasenFranja.Count == Franja)
                {
                foreach(GameObject Card in CartasenFranja)
                {
                    Card.transform.position = GraveyardCDA.transform.position;
                    Card.transform.SetParent(GraveyardCDA.transform, true);
                }
                CartasenFranja.Clear();
                }
            }
        }
}

public void Climas()
{
    climaafectado = true;
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

public int Tropillas()
{
int Tropa = 1;
if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
{
    foreach (GameObject Card in CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Rohirrim")
        {
            Tropa += 1;
        }
    }
    foreach (GameObject Card in CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Arqueros élficos")
        {
            Tropa += 1;
        }
    }
    foreach (GameObject Card in CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Máquinas de asedio")
        {
            Tropa += 1;
        }
    }
    foreach (GameObject Card in CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Uruk-Hai")
        {
            Tropa += 1;
        }
    }
    foreach (GameObject Card in CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Orcos arqueros")
        {
            Tropa += 1;
        }
    }
    foreach (GameObject Card in CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Olog-Hai")
        {
            Tropa += 1;
        }
    }
}
return Tropa;
}

public void TropillasBonus()
{
int Tropa = 1;

        if(CartasenFranja.Count == 1 || CartasenFranja.Count > 1)
        {
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Rohirrim")
            {
                Tropa +=1;
            }
        }
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Rohirrim")
            {
                Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial * Tropa;
            }
        }

        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Arqueros élficos")
            {
                Tropa +=1;
            }
        }
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Arqueros élficos")
            {
                Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial * Tropa;
            }
        }

                foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Máquinas de asedio")
            {
                Tropa +=1;
            }
        }
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Máquinas de asedio")
            {
                Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial * Tropa;
            }
        }

        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Uruk-Hai")
            {
                Tropa +=1;
            }
        }
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Uruk-Hai")
            {
                Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial * Tropa;
            }
        }
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Orcos arqueros")
            {
                Tropa +=1;
            }
        }
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Orcos arqueros")
            {
                Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial * Tropa;
            }
        }

        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Olog-Hai")
            {
                Tropa +=1;
            }
        }
        foreach (GameObject Card in CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Olog-Hai")
            {
                Card.GetComponent<ClaseCarta>().Poder = Card.GetComponent<ClaseCarta>().PoderInicial * Tropa;
            }
        }
        }
}



void Update()
{
Ronda =  GameObject.Find("CalcGanador").GetComponent<Gestordeturnosymastallas>().Ronda;
ManoPlayer = GameObject.Find("Mano");
ManoVS = GameObject.Find("Mano rival");
Mprop = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
Rprop = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>(); 
Sprop = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
Mvs = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
Rvs = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>(); 
Svs = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();  

if(ComprobadordeRonda != Ronda)
        {
            ComprobadordeRonda = Ronda;
            if(Faccion == "Comunidad del Anillo")
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
            if(Card.GetComponent<ClaseCarta>().Rango != "Oro" && Card.GetComponent<ClaseCarta>().Afectclima == false) // si no es de oro y no esta afectada ya la vuelve 1
            {
                Card.GetComponent<ClaseCarta>().Afectclima = true;
                Card.GetComponent<ClaseCarta>().Poder = 1;
            }
          }
        }
}
}