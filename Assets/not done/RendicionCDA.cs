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

    public void crinde()
    {
        if(Turno && robacda)
        {
            PlayerHand.rendido = true;
        }
        if(Turno == false && robamordor)
        {
            EnemyHand.rendido = true;
        }
    }

    void Update()
    {
        Turno = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
        PlayerHand = GameObject.FindGameObjectWithTag("manojugador").GetComponent<ClaseMano>();
        EnemyHand = GameObject.FindGameObjectWithTag("manomordor").GetComponent<ClaseMano>();
        Ronda = GameObject.Find("GestTurno").GetComponent<Turnos>().Ronda;
        robacda = GameObject.Find("MazoCDA").GetComponent<RobarCDA>().robo1;
        robamordor = GameObject.Find("MazoMordor").GetComponent<RobarMordor>().robo1;
        if(CompararRonda != Ronda)
        {
            CompararRonda = Ronda;
            PlayerHand.rendido = false;
            EnemyHand.rendido = false;
        }
    }
}
