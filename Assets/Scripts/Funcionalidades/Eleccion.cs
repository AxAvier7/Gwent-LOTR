using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleccion : MonoBehaviour
{
public bool cdaelegido = false;
public bool mordorelegido = false;
private GameObject Background;
private bool CDARobo = false;
private bool MordorRobo = false;

void Start()
{
    Background = GameObject.Find("Fondo");
}

void Update()
{
    CDARobo = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
    MordorRobo = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;
}

public void SelectCards()
{
    if(CDARobo)
    {
    cdaelegido = true;
    gameObject.transform.SetParent(Background.transform, false);
    }

    if(MordorRobo)
    {
    mordorelegido = true;
    gameObject.transform.SetParent(Background.transform, false);
    }
}
}