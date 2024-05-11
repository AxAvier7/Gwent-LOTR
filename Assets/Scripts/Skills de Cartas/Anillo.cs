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
    if(jugable && ecda && emordor && gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
    {
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 4)
        {
            Mvs.Anillo();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 5)
        {
            Rvs.Anillo();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 6)
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