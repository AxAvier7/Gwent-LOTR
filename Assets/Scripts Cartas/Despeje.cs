/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despeje : MonoBehaviour
{
public ClaseFranja Mprop; //pcc
public ClaseFranja Rprop; //pd
public ClaseFranja Sprop; //ps
public ClaseFranja Mvs; //ecc
public ClaseFranja Rvs; //ed
public ClaseFranja Svs; //es
public bool jugable;

public void Habilidad()
{
        if(jugable)
        {
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 4)
            {
                Mprop.Despeje();
                Mvs.Despeje();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 5)
            {
                Rprop.Despeje();
                Rvs.Despeje();
            }
            if(gameObject.GetComponent<ClaseCarta>().Franjita == 6)
            {
                Sprop.Despeje();
                Svs.Despeje();
            }
        }
}

void Update()
{
    //jugable = GameObject.GetComponent<PlayCDA>().jugable;
    Mprop = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
    Rprop = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
    Sprop = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
    Mvs = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
    Rvs = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
    Svs = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>();  
}
}*/