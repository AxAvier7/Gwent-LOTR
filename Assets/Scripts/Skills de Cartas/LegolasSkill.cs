using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegolasSkill : MonoBehaviour
{
public bool jugable;
public ClaseFranja Ranged;
private bool eleg = false;

public void Skill()
{
    if(jugable && eleg)
    {
        Ranged.Legolas();
    }
}

void Update()
{
jugable = gameObject.GetComponent<JugarCarta>().jugable;
eleg = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
Ranged = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>();
}
}