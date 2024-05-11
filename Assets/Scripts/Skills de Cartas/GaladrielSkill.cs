using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaladrielSkill : MonoBehaviour
{
public GameObject meucuerninho;
public GameObject climaranged;
public ClaseFranja ranged;
private bool jugable;
private bool eleg = false;

public void Skill()
{
    eleg = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
    if(jugable && eleg)
    {
        GameObject Card = Instantiate(meucuerninho, new Vector2(0,0), Quaternion.identity);
        Card.transform.SetParent(climaranged.transform, false);
        Card.transform.position = climaranged.transform.position;
        ranged.Cuerno();
    }
}
void Start()
{
    climaranged = GameObject.Find("PropClimateRanged");
    jugable = gameObject.GetComponent<JugarCarta>().jugable;
    ranged = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>();
}
}