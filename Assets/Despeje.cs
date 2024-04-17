using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despeje : MonoBehaviour
{
private GameObject CDACem;
private GameObject MordorCem;
private ClaseFranja Mprop;
private ClaseFranja Rprop;
 private ClaseFranja Sprop;
private ClaseFranja Mvs;
private ClaseFranja Rvs;
private ClaseFranja Svs;

private FranjaClima CDANiebla;
private FranjaClima CDALluvia;
private FranjaClima CDANieve;
private FranjaClima MordorNiebla;
private FranjaClima MordorLluvia;
private FranjaClima MordorNieve;
private bool jugable;

    public void Efecto()
    {
        if(jugable)
        {
            Mprop.Despeje();
            Mvs.Despeje();
            Rprop.Despeje();
            Rvs.Despeje();
            Sprop.Despeje();
            Svs.Despeje();

            PalCementerio();
        }
    }
    public void PalCementerio()
    {
        foreach(GameObject Card in CDANiebla.CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Niebla")
            {Card.transform.SetParent(CDACem.transform, false);
            Card.transform.position = CDACem.transform.position;}
        }
        foreach(GameObject Card in CDALluvia.CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Lluvia")
            {Card.transform.SetParent(CDACem.transform, false);
            Card.transform.position = CDACem.transform.position;}
        }
        foreach(GameObject Card in CDANieve.CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Nevada")
            {Card.transform.SetParent(CDACem.transform, false);
            Card.transform.position = CDACem.transform.position;}
        }
        foreach(GameObject Card in MordorNiebla.CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Niebla")
            {Card.transform.SetParent(MordorCem.transform, false);
            Card.transform.position = MordorCem.transform.position;}
        }
        foreach(GameObject Card in MordorLluvia.CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Lluvia")
            {Card.transform.SetParent(MordorCem.transform, false);
            Card.transform.position = MordorCem.transform.position;}
        }
        foreach(GameObject Card in MordorNieve.CartasenFranja)
        {
            if(Card.GetComponent<ClaseCarta>().Nombre == "Nevada")
            {Card.transform.SetParent(MordorCem.transform, false);
            Card.transform.position = MordorCem.transform.position;}
        }

        if(gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
        {
            gameObject.transform.position = CDACem.transform.position;
            gameObject.transform.SetParent(CDACem.transform, true);
        }
        if(gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
        {
            gameObject.transform.position = MordorCem.transform.position;
            gameObject.transform.SetParent(MordorCem.transform, true);
        }
    }

    void Start()
    {
        CDACem = GameObject.Find("GraveyardCDA"); //busco los cementerios
        MordorCem = GameObject.Find("GraveyardMordor");
    }
    void Update()
    {
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
       Mprop = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
       Rprop = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>(); 
       Sprop = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
       Mvs = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
       Rvs = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>(); 
       Svs = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();  
       
       CDANiebla = GameObject.FindGameObjectWithTag("CMCDA").GetComponent<FranjaClima>();
       CDALluvia = GameObject.FindGameObjectWithTag("CRCDA").GetComponent<FranjaClima>(); 
       CDANieve = GameObject.FindGameObjectWithTag("CSCDA").GetComponent<FranjaClima>(); 
       MordorNiebla = GameObject.FindGameObjectWithTag("CMMORDOR").GetComponent<FranjaClima>(); 
       MordorLluvia = GameObject.FindGameObjectWithTag("CRMORDOR").GetComponent<FranjaClima>(); 
       MordorNieve = GameObject.FindGameObjectWithTag("CSMORDOR").GetComponent<FranjaClima>();  
    }

}