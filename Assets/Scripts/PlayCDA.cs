using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCDA : MonoBehaviour
{
public GameObject Card;
public GameObject Zona;

public void PonerSiege()
{
Zona = GameObject.Find("PropSiege");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerRanged()
{
Zona = GameObject.Find("PropRanged");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerMelee()
{
Zona = GameObject.Find("PropMelee");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerSnow()
{
Zona = GameObject.Find("PropClimateSiege");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerRain()
{
Zona = GameObject.Find("PropClimateRanged");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PonerFog()
{
Zona = GameObject.Find("PropClimateMelee");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}

public void PlaySunrise() //no funciona
{
Zona = GameObject.Find("PropClimateSiege");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
Zona = GameObject.Find("PropClimateRanged");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
Zona = GameObject.Find("PropClimateMelee");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
}
}
