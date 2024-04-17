using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugarCarta : MonoBehaviour
{
public GameObject Card;
public GameObject Zona;
public bool jugable = false;
public bool PartidaTerminada;
public bool aragornrend;
public bool sauronrend;
public bool Turno = true;

//cada una de las zonas donde se van a jugar las cartas
public GameObject Manojugador;
public GameObject Manomordor;
public GameObject CDAMelee;
public GameObject CDARanged;
public GameObject CDASiege;
public GameObject MordorMelee;
public GameObject MordorRanged;
public GameObject MordorSiege;
public GameObject CMCDA;
public GameObject CRCDA;
public GameObject CSCDA;
public GameObject CMMORDOR;
public GameObject CRMORDOR;
public GameObject CSMORDOR;

public GameObject Bloqueo1;
public GameObject Bloqueo2;
private List<GameObject> CDA;
private List<GameObject> Mordor;
private int position = 0;

void Start()
{
    CDAMelee = GameObject.Find("PropMelee");
    CDARanged = GameObject.Find("PropRanged");
    CDASiege = GameObject.Find("PropSiege");
    MordorMelee = GameObject.Find("VsMelee");
    MordorRanged = GameObject.Find("VsRanged");
    MordorSiege = GameObject.Find("VsSiege");
    CMCDA = GameObject.Find("PropClimateMelee");
    CRCDA = GameObject.Find("PropClimateRanged");
    CSCDA = GameObject.Find("PropClimateSiege");
    CMMORDOR = GameObject.Find("VsClimateMelee");
    CRMORDOR = GameObject.Find("VsClimateRanged");
    CSMORDOR = GameObject.Find("VsClimateSiege");
    Manojugador = GameObject.Find("Mano");
    Manomordor = GameObject.Find("Manorival");
    PartidaTerminada = GameObject.Find("GameManager").GetComponent<Gestordeturnosymastallas>().PartidaTerminada;
}

public void Play()
{
if(PartidaTerminada == false)
       {
        if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 1 && Turno == true && aragornrend == false)
        {
            if(jugable)
            {
            Card.transform.SetParent(CDAMelee.transform, false);
            Card.transform.position = CDAMelee.transform.position;
            jugable = false;
            }
        }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 2 && Turno == true && aragornrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CDARanged.transform, false);
            Card.transform.position = CDARanged.transform.position;
            jugable = false;
            }
         }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 3 && Turno == true && aragornrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CDASiege.transform, false);
            Card.transform.position = CDASiege.transform.position;
            jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 4 && Turno == true && aragornrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CMCDA.transform, true);
            Card.transform.position = CMCDA.transform.position;
            jugable = false;
            }   
         }

          if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 5 && Turno == true && aragornrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CRCDA.transform, true);
            Card.transform.position = CRCDA.transform.position;
            jugable = false;
            }   
         }

           if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 6 && Turno == true && aragornrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CSCDA.transform, true);
            Card.transform.position = CSCDA.transform.position;
            jugable = false;
            }   
         }


            if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 1 && Turno == false && sauronrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(MordorMelee.transform, false);
            Card.transform.position = MordorMelee.transform.position;
            jugable = false;
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 2 && Turno == false && sauronrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(MordorRanged.transform, false);
            Card.transform.position = MordorRanged.transform.position;
            jugable = false;
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 3 && Turno == false && sauronrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(MordorSiege.transform, false);
            Card.transform.position = MordorSiege.transform.position;
            jugable = false;
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 4 && Turno == false && sauronrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CMMORDOR.transform, true);
            Card.transform.position = CMMORDOR.transform.position;
            jugable = false;
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 5 && Turno == false && sauronrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CRMORDOR.transform, true);
            Card.transform.position = CRMORDOR.transform.position;
            jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 6 && Turno == false && sauronrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(CSMORDOR.transform, true);
            Card.transform.position = CSMORDOR.transform.position;
            jugable = false;
            }   
         }
       }
}

public void verificador()
    {
        position = Random.Range(0, CDA.Count);
        if(CDA[position].GetComponent<ClaseCarta>().yarepartida == false)
        {
            GameObject card = Instantiate(CDA[position], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(Manojugador.transform, false);
            CDA[position].GetComponent<ClaseCarta>().yarepartida = true;
        }
        else
        {
            verificador();
        }
    }
     public void verificadorenemigo() 
    {
        position = Random.Range(0, Mordor.Count);
        if(Mordor[position].GetComponent<ClaseCarta>().yarepartida == false)
        {
            GameObject card = Instantiate(Mordor[position], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(Manomordor.transform, false);
            Mordor[position].GetComponent<ClaseCarta>().yarepartida = true;
        }
        else
        {
            verificadorenemigo();
        }
    }





















//cada uno de los metodos siguientes es para, segun el objeto al que se le asigna cada metodo, enviar un objeto a una determinada zona del tablero
// public void PonerSiege()
// {
// Zona = GameObject.Find("PropSiege");
// Card.transform.SetParent(Zona.transform, false);
// Card.transform.position = Zona.transform.position;
// }

// public void PonerRanged()
// {
// Zona = GameObject.Find("PropRanged");
// Card.transform.SetParent(Zona.transform, false);
// Card.transform.position = Zona.transform.position;
// }

// public void PonerMelee()
// {
// Zona = GameObject.Find("PropMelee");
// Card.transform.SetParent(Zona.transform, false);
// Card.transform.position = Zona.transform.position;
// }

// public void PonerSnow()
// {
// Zona = GameObject.Find("PropClimateSiege");
// Card.transform.SetParent(Zona.transform, false);
// Card.transform.position = Zona.transform.position;
// }

// public void PonerRain()
// {
// Zona = GameObject.Find("PropClimateRanged");
// Card.transform.SetParent(Zona.transform, false);
// Card.transform.position = Zona.transform.position;
// }

// public void PonerFog()
// {
// Zona = GameObject.Find("PropClimateMelee");
// Card.transform.SetParent(Zona.transform, false);
// Card.transform.position = Zona.transform.position;
// }

/*Zona = GameObject.Find("PropClimateRanged");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;
Zona = GameObject.Find("PropClimateMelee");
Card.transform.SetParent(Zona.transform, false);
Card.transform.position = Zona.transform.position;*/
}