using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleccionCDA : MonoBehaviour
{
public bool cdaelegido = false;
private GameObject Background;
private bool CDARobo = false;

void Start()
{
    Background = GameObject.Find("Fondo");
}

void Update()
{
    CDARobo = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
}

public void SelectCards()
{
    if(CDARobo)
    {cdaelegido = true;
    gameObject.transform.SetParent(Background.transform, false);}
}
}