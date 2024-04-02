using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMordor : MonoBehaviour
{
public GameObject Card;
public GameObject Zona;

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

public void PlaySunrise() //no funciona
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
}
}