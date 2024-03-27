using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class robar : MonoBehaviour
{
    //aca declaro todas las cartas de uno de los mazos
public GameObject Card;
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
public GameObject CuernoGondor;

public List <GameObject> CDA = new List<GameObject>(); //aca creo una lista en la que se van a meter las cartas
public GameObject Mano;

public void OnClick()
{
    for(int i = 0; i < 10; i++)
{
GameObject Card = Instantiate(CDA[Random.Range(0, CDA.Count)], new Vector2(0,0), Quaternion.identity);
Card.transform.SetParent(Mano.transform, false);
//aca se instancian las cartas que se metieron en una lista y se las ubica en la zona de la mano propia
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
    CDA.Add(CuernoGondor);
    }

    void Update()
    {
        
    }
}
