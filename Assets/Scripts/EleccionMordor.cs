using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleccionMordor : MonoBehaviour
{
public bool mordorelegido = false;
private GameObject Background;
private bool MordorRobo = false;

void Start()
{
    Background = GameObject.Find("Fondo");
}
void Update()
{
    MordorRobo = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;
}

public void SelectCards() // si el jugador ya robo  se vuelve verdadero el booleano de ya eligio
{
    if(MordorRobo)
    {mordorelegido = true;
    gameObject.transform.SetParent(Background.transform, false);} //se setparentea el boton al bacground para no poder verlo
}
}