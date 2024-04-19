using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSauron : MonoBehaviour
{
public bool Turnillo;
public bool used = false;
public bool elegida = false;
public ClaseFranja Melee;
public ClaseFranja Ranged;
public ClaseFranja Siege;

public void Skill()
{
    if(used == false && Turnillo == false && elegida)
    {
        Melee.Sauron();
        Ranged.Sauron();
        Siege.Sauron();
        used = true;
    }
}

void Update()
{
    elegida = GameObject.Find("ElecMordor").GetComponent<EleccionMordor>().mordorelegido;
    Melee = GameObject.Find("PropMelee").GetComponent<ClaseFranja>();
    Ranged = GameObject.Find("PropRanged").GetComponent<ClaseFranja>();
    Siege = GameObject.Find("PropSiege").GetComponent<ClaseFranja>();
    Turnillo = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
}
}