using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scripttest : MonoBehaviour
{
public Text PFranja;
public GameObject franja;

private int sumafranja = 0;

void Update()
{
int semisuma = 0;
semisuma = franja.GetComponent<ClaseFranja>().Suma;
sumafranja = semisuma;
PFranja.text = sumafranja.ToString();
}}