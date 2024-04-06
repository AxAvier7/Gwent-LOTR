using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMordor : MonoBehaviour
{
public GameObject Card;
public GameObject Zona;

//cada uno de los metodos siguientes es para, segun el objeto al que se le asigna cada metodo, enviar un objeto a una determinada zona del tablero
public void PonerSiege()
{
Zona = GameObject.Find("VsSiege");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerRanged()
{
Zona = GameObject.Find("VsRanged");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerMelee()
{
Zona = GameObject.Find("VsMelee");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerSnow()
{
Zona = GameObject.Find("VsClimateSiege");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerRain()
{
Zona = GameObject.Find("VsClimateRanged");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerFog()
{
Zona = GameObject.Find("VsClimateMelee");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

/*public void PlaySunrise()      //lo mismo que en el PlaySunrise del script PlayCDA
{
Zona = GameObject.Find("VsClimateSiege");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
Zona = GameObject.Find("VsClimateRanged");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
Zona = GameObject.Find("VsClimateMelee");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}*/
}