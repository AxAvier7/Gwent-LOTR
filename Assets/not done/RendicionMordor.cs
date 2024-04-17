using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MordorRendicion : MonoBehaviour
{
    public bool Turno;
    public int Ronda;
    public int CompararRonda = 1;
    public ClaseMano PlayerHand;
    public ClaseMano EnemyHand;

    public void crinde()
    {
        if(Turno)
        {
            PlayerHand.rendido = true;
        }
        if(Turno == false)
        {
            EnemyHand.rendido = true;
        }
    }

    void Update()
    {
        Turno = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
        PlayerHand = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<ClaseMano>();
        EnemyHand = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<ClaseMano>();
        Ronda = GameObject.Find("GestTurno").GetComponent<Turnos>().Ronda;
        if(CompararRonda != Ronda)
        {
            CompararRonda = Ronda;
            PlayerHand.rendido = false;
            EnemyHand.rendido = false;
        }
    }
}
