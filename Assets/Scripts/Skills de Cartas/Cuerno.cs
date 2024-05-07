using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cuerno : MonoBehaviour
{
public ClaseFranja Mprop;
public ClaseFranja Rprop;
public ClaseFranja Sprop;
public bool jugable;
private bool ecda;
private bool emordor;

public void Habilidad()
{
    if(jugable && ecda && emordor)
    {
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 4 && gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
            {
                Mprop.Cuerno();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 5 && gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
            {
                Rprop.Cuerno();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 6 && gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
            {
                Sprop.Cuerno();
            }
    }
}

void Update()
    {
    jugable = gameObject.GetComponent<JugarCarta>().jugable;
    Mprop = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>(); 
    Rprop = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>(); 
    Sprop = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
    emordor = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
    ecda = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
    }
}