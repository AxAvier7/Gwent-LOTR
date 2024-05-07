using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendicion : MonoBehaviour
{
    public bool Turno;
    public int Ronda;
    public int CompararRonda = 1;
    public ClaseMano PlayerHand;
    public ClaseMano EnemyHand;
    private bool robacda;
    private bool robamordor;

    public void rindecda()
    {
        if(Turno && robacda)
        {
            PlayerHand.rendido = true;
        }
    }

    public void rindemor()
    {
        if(Turno == false && robamordor)
        {
            EnemyHand.rendido = true;
        }
    }

    void Update()
    {
        Turno = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
        PlayerHand = GameObject.FindGameObjectWithTag("Manojugador").GetComponent<ClaseMano>();
        EnemyHand = GameObject.FindGameObjectWithTag("Manomordor").GetComponent<ClaseMano>();
        Ronda = GameObject.Find("GestTurno").GetComponent<Turnos>().Ronda;
        robacda = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
        robamordor = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;

        if(CompararRonda != Ronda)
            {
                CompararRonda = Ronda;
                PlayerHand.rendido = false;
                EnemyHand.rendido = false;
            }
    }
}
