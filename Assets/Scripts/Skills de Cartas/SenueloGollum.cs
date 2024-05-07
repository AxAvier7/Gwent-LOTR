using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenueloGollum : MonoBehaviour
{
    public ClaseFranja Melee1;
    public ClaseFranja Melee2;
    public bool jugable;
    private bool eleg = false;

    public void Skill()
    {
        if(jugable && eleg)
        {
            if(gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && gameObject.GetComponent<ClaseCarta>().Franjita == 1)
            {
                Melee1.Gollum();
            }
            if(gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor" && gameObject.GetComponent<ClaseCarta>().Franjita == 1)
            {
                Melee2.Gollum();
            }
        }
    }

    void Update()
    {
       eleg = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
       Melee1 = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>(); 
       Melee2 = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
    }
}