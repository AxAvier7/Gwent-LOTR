using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobarMordor : MonoBehaviour
{
    //aca declaro todas las cartas de uno de los mazos
public GameObject Card;
public GameObject UrukHai1;
public GameObject UrukHai2;
public GameObject UrukHai3;
public GameObject OrcArcher1;
public GameObject OrcArcher2;
public GameObject OrcArcher3;
public GameObject OlogHai1;
public GameObject OlogHai2;
public GameObject OlogHai3;
public GameObject Bolg;
public GameObject Lurtz;
public GameObject Ratbag;
public GameObject Azog;
public GameObject Balrog;
public GameObject Smaug;
public GameObject Saruman;
public GameObject Gollum;
public GameObject Nazgul;
public GameObject RingMelee;
public GameObject RingRanged;
public GameObject RingSiege;
public GameObject Despeje3;
public GameObject Despeje4;
public GameObject Lluvia3;
public GameObject Lluvia4;
public GameObject Niebla3;
public GameObject Niebla4;
public GameObject Nevada3;
public GameObject Nevada4;

public bool robo1 = false;
public bool robo2 = false;
public bool robo3 = false;
private int Ronda = 1;
private bool Turno;
private int posicion = 0;


public List <GameObject> Mordor = new List<GameObject>(); //aca creo una lista en la que se van a meter las cartas
public GameObject Mano;



public void revisarjugada()
    {
        posicion = Random.Range(0, Mordor.Count);
        if(Mordor[posicion].GetComponent<ClaseCarta>().yarepartida == false)
        {
            GameObject Card = Instantiate(Mordor[posicion], new Vector2(0,0), Quaternion.identity);
            Card.transform.SetParent(Mano.transform, false);
            Mordor[posicion].GetComponent<ClaseCarta>().yarepartida = true;
        }
        else
        {
            revisarjugada();
        }
    }

public void OnClick()
{
    if(Turno == false)
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
    Mordor.Add(UrukHai1);
    Mordor.Add(UrukHai2);
    Mordor.Add(UrukHai3);
    Mordor.Add(OrcArcher1);
    Mordor.Add(OrcArcher2);
    Mordor.Add(OrcArcher3);
    Mordor.Add(OlogHai1);
    Mordor.Add(OlogHai2);
    Mordor.Add(OlogHai3);
    Mordor.Add(Bolg);
    Mordor.Add(Lurtz);
    Mordor.Add(Ratbag);
    Mordor.Add(Azog);
    Mordor.Add(Balrog);
    Mordor.Add(Smaug);
    Mordor.Add(Saruman);
    Mordor.Add(Gollum);
    Mordor.Add(Nazgul);
    Mordor.Add(RingMelee);
    Mordor.Add(RingRanged);
    Mordor.Add(RingSiege);
    Mordor.Add(Despeje3);
    Mordor.Add(Despeje4);
    Mordor.Add(Lluvia3);
    Mordor.Add(Lluvia4);
    Mordor.Add(Niebla3);
    Mordor.Add(Niebla4);
    Mordor.Add(Nevada3);
    Mordor.Add(Nevada4);
    

    foreach(GameObject Card in Mordor)
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