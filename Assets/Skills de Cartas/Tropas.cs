using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tropas : MonoBehaviour
{
public ClaseFranja sCaC;
public ClaseFranja sR;
public ClaseFranja sS;
public ClaseFranja mCaC;
public ClaseFranja mR;
public ClaseFranja mS;
private int Poder;
public bool jugable;
public bool eleg = false;
private bool elegsauron = false;

public void Skill()
{
    if(jugable)
    {
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Soldados de Rohan" && eleg)
        {
            Poder = sCaC.Tropillas();
            sCaC.TropillasBonus();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Arqueros élficos" && eleg)
        {
            Poder = sR.Tropillas();
            sR.TropillasBonus();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Máquinas de asedio" && eleg)
        {
            Poder = sS.Tropillas();
            sS.TropillasBonus();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Uruk-Hai" && elegsauron)
        {
            Poder = mCaC.Tropillas();
            mCaC.TropillasBonus();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Orcos arqueros" && elegsauron)
        {
            Poder = mR.Tropillas();
            mR.TropillasBonus();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Olog-Hai" && elegsauron)
        {
            Poder = mS.Tropillas();
            mS.TropillasBonus();
        }
    }
}


void Update()
{
    eleg = GameObject.Find("ElecCDA").GetComponent<EleccionCDA>().cdaelegido;
    elegsauron = GameObject.Find("ElecMordor").GetComponent<EleccionMordor>().mordorelegido;
    jugable = gameObject.GetComponent<JugarCarta>().jugable;
    sCaC = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
    sR = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>();
    sS = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>();
    mCaC = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>();
    mR = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>();
    mS = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();
}
}