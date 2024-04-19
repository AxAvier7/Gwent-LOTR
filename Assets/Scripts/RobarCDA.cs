using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RobarCDA : MonoBehaviour
{
    //aca declaro todas las cartas del mazo de la Comunidad del Anillo
public GameObject GondorWarrior1;
public GameObject GondorWarrior2;
public GameObject GondorWarrior3;
public GameObject ElficArcher1;
public GameObject ElficArcher2;
public GameObject ElficArcher3;
public GameObject SiegeMachine1;
public GameObject SiegeMachine2;
public GameObject SiegeMachine3;
public GameObject Barbol;
public GameObject Boromir;
public GameObject Elrond;
public GameObject Frodo;
public GameObject Galadriel;
public GameObject Gandalf;
public GameObject Gimli;
public GameObject Legolas;
public GameObject Sam;
public GameObject Talion;
public GameObject Despeje;
public GameObject Despeje2;
public GameObject Lluvia;
public GameObject Lluvia2;
public GameObject Niebla;
public GameObject Niebla2;
public GameObject Nevada;
public GameObject Nevada2;
public GameObject CuernoGondorMelee;
public GameObject CuernoGondorRanged;
public GameObject CuernoGondorSiege;

public bool robo1 = false;
public bool robo2 = false;
public bool robo3 = false;
private int Ronda = 1;
private bool Turno;
private int posicion = 0;

public List <GameObject> CDA = new List<GameObject>(); //aca creo una lista en la que se van a meter las cartas
public GameObject Mano;

public void revisarjugada()
    {
        posicion = Random.Range(0, CDA.Count);
        if(CDA[posicion].GetComponent<ClaseCarta>().yarepartida == false)
        {
            GameObject Card = Instantiate(CDA[posicion], new Vector2(0,0), Quaternion.identity);
            Card.transform.SetParent(Mano.transform, false);
            CDA[posicion].GetComponent<ClaseCarta>().yarepartida = true;
        }
        else
        {
            revisarjugada();
        }
    }

public void OnClick()
{
        if(Turno)
        {
        if(robo1 == false && Ronda == 1)
        {
        for (int i= 0; i < 10; i ++)
        { 
            revisarjugada();
        }
        robo1 = true;
        }

        if(robo2 == false && Ronda == 2)
        {
        for (int i= 0; i < 2; i ++)
        {
            revisarjugada();
        }
        robo2 = true;
        }

        if(robo3 == false && Ronda == 3)
        {
        for (int i= 0; i < 2; i ++)
        { 
            revisarjugada();
        }
        robo3 = true;
        }
}
    }
    void Start()
    {
    //aca añado todas las cartas a la lista de cartas
    CDA.Add(GondorWarrior1);
    CDA.Add(GondorWarrior2);
    CDA.Add(GondorWarrior3);
    CDA.Add(ElficArcher1);
    CDA.Add(ElficArcher2);
    CDA.Add(ElficArcher3);
    CDA.Add(SiegeMachine1);
    CDA.Add(SiegeMachine2);
    CDA.Add(SiegeMachine3); 
    CDA.Add(Barbol);
    CDA.Add(Boromir);
    CDA.Add(Elrond);
    CDA.Add(Frodo);
    CDA.Add(Galadriel);
    CDA.Add(Gandalf);
    CDA.Add(Gimli);
    CDA.Add(Legolas);
    CDA.Add(Sam);
    CDA.Add(Talion);
    CDA.Add(Despeje);
    CDA.Add(Despeje2);
    CDA.Add(Lluvia);
    CDA.Add(Lluvia2);
    CDA.Add(Nevada);
    CDA.Add(Nevada2);
    CDA.Add(Niebla);
    CDA.Add(Niebla2);
    CDA.Add(CuernoGondorMelee);
    CDA.Add(CuernoGondorRanged);
    CDA.Add(CuernoGondorSiege);

    foreach(GameObject Card in CDA)
    {
        Card.GetComponent<ClaseCarta>().yarepartida = false;
    }
    }

    void Update()
    {
        Ronda = GameObject.Find("CalcGanador").GetComponent<Gestordeturnosymastallas>().Ronda;
        Turno = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
    }
}
