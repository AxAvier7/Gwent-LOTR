using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPropSnow : MonoBehaviour
{
public GameObject Card;
public GameObject Zona;
/*
private bool jugable = true;
private GameObject contturnos;
private bool turn;
*/
    void Start()
    {
        Zona = GameObject.Find("PropClimateSiege");
        //contturnos = GameObject.Find("aqui va un objeto que no he creado")
    }

    public void Ponercarta()
{
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}
    void Update()
    {
        
    }
}
