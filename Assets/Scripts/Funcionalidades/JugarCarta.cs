using System.Collections.Generic;
using UnityEngine;

public class JugarCarta : MonoBehaviour
{
public GameObject Card;
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

public void Play()
{
   if(PartidaTerminada == false && !aragornrend && aragorneleg && !sauronrend && sauroneleg && jugable)
   {
      if(Card.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo" && Turno == true)
      {
         switch (Card.GetComponent<ClaseCarta>().Franjita)
         {
            case 1:
               JugarCartaEnZona(CDAMelee);
               break;
            case 2:
               JugarCartaEnZona(CDARanged);
               break;
            case 3:
               JugarCartaEnZona(CDASiege);
               break;
            case 4:
               JugarCartaEnZona(CMCDA);
               break;
            case 5:
               JugarCartaEnZona(CRCDA);
               break;
            case 6:
               JugarCartaEnZona(CSCDA);
               break;
         }
      }

      if(Card.GetComponent<ClaseCarta>().Faccion == "Mordor" && Turno == false)
      {
         switch (Card.GetComponent<ClaseCarta>().Franjita)
         {
            case 1:
               JugarCartaEnZona(MordorMelee);
               break;
            case 2:
               JugarCartaEnZona(MordorRanged);
               break;
            case 3:
               JugarCartaEnZona(MordorSiege);
               break;
            case 4:
               JugarCartaEnZona(CMMORDOR);
               break;
            case 5:
               JugarCartaEnZona(CRMORDOR);
               break;
            case 6:
               JugarCartaEnZona(CSMORDOR);
               break;
         }
      }
   }
}
   private void JugarCartaEnZona(GameObject zona)
   {
      Card.transform.SetParent(zona.transform, false);
      Card.transform.position = zona.transform.position;
      jugable = false;
   }

   public void verificadorcda()
   {
      position = UnityEngine.Random.Range(0, CDA.Count);
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
      position = UnityEngine.Random.Range(0, Mordor.Count);
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