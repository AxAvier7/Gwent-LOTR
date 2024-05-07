using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anillo : MonoBehaviour
{
public ClaseFranja Mvs;
public ClaseFranja Rvs;
public ClaseFranja Svs;
public bool jugable;
private bool ecda;
private bool emordor;

public void Habilidad()
{
    if(jugable && ecda && emordor)
    {
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 4 && gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
            {
                Mvs.Anillo();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 5 && gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
            {
                Rvs.Anillo();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 6 && gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
            {
                Svs.Anillo();
            }
    }
}

void Update()
    {
    jugable = gameObject.GetComponent<JugarCarta>().jugable;
    Mvs = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
    Rvs = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>(); 
    Svs = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();  
    emordor = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
    ecda = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
    }
}