// using UnityEngine;

// public class DamageVHeal : MonoBehaviour
// {
//     public ClaseFranja Mprop; //Franja Melee Propia
//     public ClaseFranja Rprop; //Franja Ranged Propia
//     public ClaseFranja Sprop; //Franja Siege Propia
//     public ClaseFranja Mvs; //Franja Melee Rival
//     public ClaseFranja Rvs; //Franja Ranged Rival
//     public ClaseFranja Svs; //Franja Siege Rival

//     private GameObject CDACem;
//     private GameObject MordorCem;

//     public bool jugable;
//     private bool elegMordor = false;
//     private bool elegCDA = false;
//     public bool Turn;

//     public void Heal()
//     {
//         if (jugable && elegCDA && elegMordor)
//         {
//             var carta = gameObject.GetComponent<ClaseCarta>();
            
//             switch (carta.Faccion)
//             {
//                 case "Comunidad del Anillo":
//                     Mprop.Healing();
//                     Rprop.Healing();
//                     Sprop.Healing();
//                     break;
//                 case "Mordor":
//                     Mvs.Healing();
//                     Rvs.Healing();
//                     Svs.Healing();
//                     break;
//             }
//         }
//     }

//     public void Damage()
//     {
//         if(jugable && elegCDA && elegMordor)
//         {
//             var carta = gameObject.GetComponent<ClaseCarta>();
//             switch (carta.Faccion)
//             {
//                 case "Comunidad del Anillo":
//                     Mprop.Damaging();
//                     Rprop.Damaging();
//                     Sprop.Damaging();
//                     break;
//                 case "Mordor":
//                     Mvs.Damaging();
//                     Rvs.Damaging();
//                     Svs.Damaging();
//                     break;
//             }
//         }
//     }


//     public void ReturntoGraveyard(int power)
//     {
//         foreach(GameObject Card in Mprop.CartasenFranja)
//         {
//             {Card.transform.SetParent(CDACem.transform, false);
//             Card.transform.position = CDACem.transform.position;}
//         }
//         foreach(GameObject Card in Rprop.CartasenFranja)
//         {
//             {Card.transform.SetParent(CDACem.transform, false);
//             Card.transform.position = CDACem.transform.position;}
//         }
//         foreach(GameObject Card in Sprop.CartasenFranja)
//         {
//             {Card.transform.SetParent(CDACem.transform, false);
//             Card.transform.position = CDACem.transform.position;}
//         }

//         foreach(GameObject Card in Mvs.CartasenFranja)
//         {
//             {Card.transform.SetParent(MordorCem.transform, false);
//             Card.transform.position = MordorCem.transform.position;}
//         }
//         foreach(GameObject Card in Rvs.CartasenFranja)
//         {
//             {Card.transform.SetParent(MordorCem.transform, false);
//             Card.transform.position = MordorCem.transform.position;}
//         }
//         foreach(GameObject Card in Svs.CartasenFranja)
//         {
//             {Card.transform.SetParent(MordorCem.transform, false);
//             Card.transform.position = MordorCem.transform.position;}
//         }

//         if(power<0)
//         {
//             if(gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
//             {
//                 gameObject.transform.position = CDACem.transform.position;
//                 gameObject.transform.SetParent(CDACem.transform, true);
//             }
//             if(gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
//             {
//                 gameObject.transform.position = MordorCem.transform.position;
//                 gameObject.transform.SetParent(MordorCem.transform, true);
//             }
//         }
//     }

//     void Update()
//     {
//         Mprop = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>(); 
//         Rprop = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>(); 
//         Sprop = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
//         Mvs = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
//         Rvs = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>(); 
//         Svs = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();  
        
//         jugable = gameObject.GetComponent<JugarCarta>().jugable;
//         elegMordor = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
//         elegCDA = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
//         CDACem = GameObject.Find("Graveyard CDA");
//         MordorCem = GameObject.Find("Graveyard Mordor");
//         Turn = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
//     }
// }