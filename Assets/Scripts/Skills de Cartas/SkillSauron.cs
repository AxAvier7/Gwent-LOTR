using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSauron : MonoBehaviour
{
 public ClaseFranja CDAM;
public ClaseFranja CDAR;
public ClaseFranja CDAS;
public bool used = false; 
public bool elegida = false;
public bool Turnillo;

public void Skill()
{
    int cdam = CDAM.MayorCarta(); 
    int cdar = CDAR.MayorCarta();
    int cdas = CDAS.MayorCarta();
    int mayor = Mathf.Max(cdam, Mathf.Max(cdar, Mathf.Max(cdas)));
 
    if (Turnillo == false && elegida && used == false)
    {
        if(cdam == mayor)
        {
            CDAM.EliminarMayorCarta(mayor);
            used = true;
            return;        
        }

        if(cdar == mayor)
        {
            CDAR.EliminarMayorCarta(mayor);
            used = true;
            return;
        }
        if(cdas == mayor)
        {
            CDAS.EliminarMayorCarta(mayor);
            used = true;
            return;
        }
    }
}
void Update()
{
    elegida = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
    CDAM = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
    CDAR = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>();
    CDAS = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>();
    Turnillo = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
}
}