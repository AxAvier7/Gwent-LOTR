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
private bool aragorneleg;
private bool sauroneleg;

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
    Manomordor = GameObject.Find("Mano rival");
    PartidaTerminada = GameObject.Find("CalcGanador").GetComponent<Gestordeturnosymastallas>().FinPartida;
}

enum jugador
{
   Comunidad = 1,
   Jugador2 =2
}
public void Play()
{
if(PartidaTerminada == false)
       {
        if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 1 && Turno == true && !aragornrend && aragorneleg)
        {
            if(jugable)
            {
            Card.transform.SetParent(CDAMelee.transform, false);
            Card.transform.position = CDAMelee.transform.position;
            jugable = false;
            }
        }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 2 && Turno == true && aragornrend == false && aragorneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(CDARanged.transform, false);
            Card.transform.position = CDARanged.transform.position;
            jugable = false;
            }
         }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 3 && Turno == true && aragornrend == false && aragorneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(CDASiege.transform, false);
            Card.transform.position = CDASiege.transform.position;
            jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 4 && Turno == true && aragornrend == false && aragorneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(CMCDA.transform, true);
            Card.transform.position = CMCDA.transform.position;
            jugable = false;
            }   
         }

          if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 5 && Turno == true && aragornrend == false && aragorneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(CRCDA.transform, true);
            Card.transform.position = CRCDA.transform.position;
            jugable = false;
            }   
         }

           if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Card.GetComponent<ClaseCarta>().Franjita == 6 && Turno == true && aragornrend == false && aragorneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(CSCDA.transform, true);
            Card.transform.position = CSCDA.transform.position;
            jugable = false;
            }   
         }


            if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 1 && Turno == false && sauronrend == false && sauroneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(MordorMelee.transform, false);
            Card.transform.position = MordorMelee.transform.position;
            jugable = false;
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 2 && Turno == false && sauronrend == false && sauroneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(MordorRanged.transform, false);
            Card.transform.position = MordorRanged.transform.position;
            jugable = false;
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 3 && Turno == false && sauronrend == false && sauroneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(MordorSiege.transform, false);
            Card.transform.position = MordorSiege.transform.position;
            jugable = false;
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 4 && Turno == false && sauronrend == false && sauroneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(CMMORDOR.transform, true);
            Card.transform.position = CMMORDOR.transform.position;
            jugable = false;
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 5 && Turno == false && sauronrend == false && sauroneleg)
         {
            if(jugable)
            {
            Card.transform.SetParent(CRMORDOR.transform, true);
            Card.transform.position = CRMORDOR.transform.position;
            jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Card.GetComponent<ClaseCarta>().Franjita == 6 && Turno == false && sauronrend == false && sauroneleg)
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

public void verificadorcda()
    {
        position = Random.Range(0, CDA.Count);
        if(CDA[position].GetComponent<ClaseCarta>().yarepartida == false)
        {
            GameObject Card = Instantiate(CDA[position], new Vector2(0,0), Quaternion.identity);
            Card.transform.SetParent(Manojugador.transform, false);
            CDA[position].GetComponent<ClaseCarta>().yarepartida = true;
        }
        else
        {
            verificadorcda();
        }
    }
     public void verificadormordor() 
    {
        position = Random.Range(0, Mordor.Count);
        if(Mordor[position].GetComponent<ClaseCarta>().yarepartida == false)
        {
            GameObject Card = Instantiate(Mordor[position], new Vector2(0,0), Quaternion.identity);
            Card.transform.SetParent(Manomordor.transform, false);
            Mordor[position].GetComponent<ClaseCarta>().yarepartida = true;
        }
        else
        {
            verificadormordor();
        }
    }

   void Update()
    {
      Manojugador = GameObject.Find("Mano");
      Manomordor = GameObject.Find("Mano rival");
      aragorneleg = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
      sauroneleg = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
      Turno = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
      CDA = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().CDA;
      Mordor = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().Mordor;
      aragornrend = GameObject.Find("Mano").GetComponent<ClaseMano>().rendido;
      sauronrend = GameObject.Find("Mano rival").GetComponent<ClaseMano>().rendido;
    }
}