using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puntosfranja : MonoBehaviour
{
public Text PFranja;
public GameObject Melee;
public GameObject Ranged;
public GameObject Siege;
private int sumafranja = 0;
//acá declaré todas las variables y objetos que voy a utilizar en el script

void Update()  
{
int semisuma = 0;
semisuma = Melee.GetComponent<ClaseFranja>().Suma + Ranged.GetComponent<ClaseFranja>().Suma + Siege.GetComponent<ClaseFranja>().Suma;
sumafranja = semisuma;
PFranja.text = sumafranja.ToString();
//metodo para sumar el poder de cada franja y que el resultado sea el poder total de cada faccion en la ronda
}
}
