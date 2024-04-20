using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseMano : MonoBehaviour
{
     private GameObject Cardentry;
     public List<GameObject> CardsinFrange;
     public int Cartas = 0;
     public int Cartasdevueltas = 0;
     public bool rendido = false;

     private void OnCollisionEnter2D(Collision2D collision) //metodo que detecta cuando entra una carta a la zona de la mano del jugador
     {
        Cardentry = collision.gameObject;
        CardsinFrange.Add(Cardentry);
        Cartas += 1;
     }

    private void OnCollisionExit2D(Collision2D collision) //metodo que detecta cuando sale una carta de la mano del jugador
     {
        CardsinFrange.RemoveAt(0);
        Cartas -= 1;
     }
}