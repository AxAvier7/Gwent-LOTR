using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimaSkill : MonoBehaviour
{
public ClaseFranja Mprop;
public ClaseFranja Rprop;
public ClaseFranja Sprop;
public ClaseFranja Mvs;
public ClaseFranja Rvs;
public ClaseFranja Svs;
public bool jugable;

    public void Clima()
    {
        if(jugable)
        {
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 4)
            {
                Mprop.Climas();
                Mvs.Climas();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 5)
            {
                Rprop.Climas();
                Rvs.Climas();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 6)
            {
                Sprop.Climas();
                Svs.Climas();
            }
        }
    }

    void Update()
    {
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
       Mprop = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
       Rprop = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>(); 
       Sprop = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
       Mvs = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
       Rvs = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>(); 
       Svs = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();  
    }

}
