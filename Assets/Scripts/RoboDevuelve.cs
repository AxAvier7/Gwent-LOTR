using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboDevuelve : MonoBehaviour
{
    public ClaseMano manocda;
    public ClaseMano manomordor;
    public RobarCDA mazojugador;
    public RobarMordor mazoenemigo;
    public GameObject InfoZona;
    private Turnos Turn;
    private bool elegcda;
    private bool elegmordor;

    void Start()
    {
        manocda = GameObject.FindGameObjectWithTag("Manojugador").GetComponent<ClaseMano>();
        mazojugador = GameObject.FindGameObjectWithTag("mazocda").GetComponent<RobarCDA>();
        manomordor = GameObject.FindGameObjectWithTag("Manomordor").GetComponent<ClaseMano>();
        mazoenemigo = GameObject.FindGameObjectWithTag("mazomordor").GetComponent<RobarMordor>();
        InfoZona = GameObject.Find("InfoZone");
    }

    public void Devolver()
    {
        if(Input.GetMouseButtonUp(0) && manocda.Cartasdevueltas < 2 && Turn.Turno && elegcda == false && gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
        {
            manocda.Cartasdevueltas += 1;
            gameObject.GetComponent<ClaseCarta>().yarepartida = false;
            mazojugador.revisarjugada();
            Destroy(gameObject);
            Destroy(InfoZona.transform.GetChild(0).gameObject);
            // Destroy(InfoZona.transform.GetChild(1).gameObject);
            // Destroy(InfoZona.transform.GetChild(2).gameObject);
            // Destroy(InfoZona.transform.GetChild(3).gameObject);
            // Destroy(InfoZona.transform.GetChild(4).gameObject);
            // Destroy(InfoZona.transform.GetChild(5).gameObject);
            // Destroy(InfoZona.transform.GetChild(6).gameObject);
            // Destroy(InfoZona.transform.GetChild(7).gameObject);
            // Destroy(InfoZona.transform.GetChild(8).gameObject);
            // Destroy(InfoZona.transform.GetChild(9).gameObject);
            // Destroy(InfoZona.transform.GetChild(10).gameObject);
            // Destroy(InfoZona.transform.GetChild(11).gameObject);
            // Destroy(InfoZona.transform.GetChild(12).gameObject);
            // Destroy(InfoZona.transform.GetChild(13).gameObject);
            // Destroy(InfoZona.transform.GetChild(14).gameObject);
            // Destroy(InfoZona.transform.GetChild(15).gameObject);
        }

        if(Input.GetMouseButtonUp(0) && manomordor.Cartasdevueltas < 2 && Turn.Turno == false && elegmordor == false && gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
        {
            manomordor.Cartasdevueltas += 1;
            gameObject.GetComponent<ClaseCarta>().yarepartida = false;
            mazoenemigo.revisarjugada();
            Destroy(gameObject);
            Destroy(InfoZona.transform.GetChild(0).gameObject);
            // Destroy(InfoZona.transform.GetChild(1).gameObject);
            // Destroy(InfoZona.transform.GetChild(2).gameObject);
            // Destroy(InfoZona.transform.GetChild(3).gameObject);
            // Destroy(InfoZona.transform.GetChild(4).gameObject);
            // Destroy(InfoZona.transform.GetChild(5).gameObject);
            // Destroy(InfoZona.transform.GetChild(6).gameObject);
            // Destroy(InfoZona.transform.GetChild(7).gameObject);
            // Destroy(InfoZona.transform.GetChild(8).gameObject);
            // Destroy(InfoZona.transform.GetChild(9).gameObject);
            // Destroy(InfoZona.transform.GetChild(10).gameObject);
            // Destroy(InfoZona.transform.GetChild(11).gameObject);
            // Destroy(InfoZona.transform.GetChild(12).gameObject);
            // Destroy(InfoZona.transform.GetChild(13).gameObject);
            // Destroy(InfoZona.transform.GetChild(14).gameObject);
            // Destroy(InfoZona.transform.GetChild(15).gameObject);
        }
    }

    void Update()
    {
        Turn = GameObject.FindGameObjectWithTag("ContTurno").GetComponent<Turnos>();
        elegcda = GameObject.Find("ElecCDA").GetComponent<EleccionCDA>().cdaelegido;
        elegmordor = GameObject.Find("ElecMordor").GetComponent<EleccionMordor>().mordorelegido;
    }
}