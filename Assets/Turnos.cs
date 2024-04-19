using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turnos : MonoBehaviour
{
    public int Ronda = 1;
    public bool Turno = true;
    public ClaseMano ManoCDA;
    public ClaseMano ManoMordor;
    public GameObject TaparManoCDA;
    public GameObject TaparManoMordor;
    public Text CDARendidotxt;
    public Text MordorRendidotxt;
    // public bool skillaragorn;
    public bool skillsauron;
    // private int aragorn = 1;
    private int sauron = 1;
    private int Mano1 = 0;
    private int Mano2 = 0;
    private int comparador1 = 0;
    private int comparador2 = 0;
    private RectTransform taparmanoCDA;
    private RectTransform taparmanomordor;
    private bool eligearagorn;
    private bool eligesauron;

    private bool CDARoboRonda1;
    private bool CDARoboRonda2;
    private bool CDARoboRonda3;
    private bool MordorRoboRonda1;
    private bool MordorRoboRonda2;
    private bool MordorRoboRonda3;

    public string Ganador;
    private int CompRonda = 1;

void Start()
{
Ganador = "nulo";
taparmanoCDA = TaparManoCDA.GetComponent<RectTransform>();
taparmanomordor = TaparManoMordor.GetComponent<RectTransform>();
}


void Update()
{
eligearagorn = GameObject.Find("ElecCDA").GetComponent<EleccionCDA>().cdaelegido;
eligesauron =GameObject.Find("ElecMordor").GetComponent<EleccionMordor>().mordorelegido;
Ganador = GameObject.Find("GameManager").GetComponent<Gestordeturnosymastallas>().Ganador;

// skillaragorn = GameObject.Find("Aragorn").GetComponent<>().Utilizada;
skillsauron = GameObject.Find("Sauron").GetComponent<SkillSauron>().used;

ManoCDA = GameObject.FindGameObjectWithTag("Manojugador").GetComponent<ClaseMano>();
ManoMordor = GameObject.FindGameObjectWithTag("Manomordor").GetComponent<ClaseMano>();

CDARoboRonda1 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
CDARoboRonda2 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo2;
CDARoboRonda3 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo3;
MordorRoboRonda1 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;
MordorRoboRonda2 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo2;
MordorRoboRonda3 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo3;

Ronda = GameObject.Find("GameManager").GetComponent<Gestordeturnosymastallas>().Ronda;
Mano1 = GameObject.Find("Mano").GetComponent<ClaseMano>().Cartas;
Mano2 = GameObject.Find("Mano rival").GetComponent<ClaseMano>().Cartas;

        // if(Turno && skillaragorn && aragorn == 1 && eligearagorn)
        // {
        //     aragorn += 1;
        //     Turno = false;
        // }
        if(Turno == false && skillsauron && sauron == 1 && eligesauron) //cambia el turno cuando Sauron use su habilidad
        {
            sauron += 1;
            Turno = true;
        }


       if(Turno) //cambio de turno 
       {
        taparmanoCDA.sizeDelta = new Vector2(0, 0);
        taparmanomordor.sizeDelta = new Vector2(1300, 170); // aqui cambio el size del bloque para que el oponente no vea tus cartas
        if(Mano1 == 0 && Ronda == 1 && CDARoboRonda1 && eligearagorn) //esto es para cuando te quedes sin cartas le toque solo al oponente y lo repito para cada ronda
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 2 && CDARoboRonda2 && eligearagorn)
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 3 && CDARoboRonda3 && eligearagorn)
        {
            Turno = false;
        }

        if(comparador1 != Mano1 && eligearagorn) // si detecta que hay una diferencia en las cartas es que se ha jugado  y cambia el turno
        {
            comparador1 = Mano1;
            Turno = false;
        }
       }


       if(Turno == false) //cambio de turno y repito lo mismo de arriba
       {    
        taparmanomordor.sizeDelta = new Vector2(0, 0);
        taparmanoCDA.sizeDelta = new Vector2(1300, 170); 
        if(Mano2 == 0 && Ronda == 1 && MordorRoboRonda1 && eligesauron)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 2 && MordorRoboRonda2 && eligesauron)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 3 && MordorRoboRonda3 && eligesauron)
        {
            Turno = true;
        }

        if(comparador2 != Mano2 && eligesauron)
        {
            comparador2 = Mano2;
            Turno = true;
        }
       }

       if(ManoCDA.rendido) //cuando la comunidad se rinde, pasa a ser turno de mordor y sale el mensaje de rendicion
        {
            Turno = false;
            CDARendidotxt.text = "La Comunidad Se Ha Rendido";
        }
        else
        {
            CDARendidotxt.text = "";
        }

        if(ManoMordor.rendido) //cuando mordor se rinde, pasa a ser turno de la comunidad y sale el mensaje de rendicion
        {
            Turno = true;
            MordorRendidotxt.text = "Mordor Se Ha Rendido";
        }
        else
        {
            MordorRendidotxt.text = "";
        }
        
        //estos 3 que vienen son para que cuando se rinda alguien se tapen las 2 manos
        if(ManoMordor.rendido && ManoCDA.rendido)
        {
            taparmanomordor.sizeDelta = new Vector2(1300, 170);
            taparmanoCDA.sizeDelta = new Vector2(1300, 170);
        }
        if(ManoMordor.rendido && Mano2 == 0)
        {
            taparmanomordor.sizeDelta = new Vector2(1300, 170);
            taparmanoCDA.sizeDelta = new Vector2(1300, 170);
        }
        if(Mano1 == 0 && ManoCDA.rendido)
        {
            taparmanomordor.sizeDelta = new Vector2(1300, 170);
            taparmanoCDA.sizeDelta = new Vector2(1300, 170);
        }

         //para ver quien empieza la 2da y 3ra rondas
        if(Ronda != CompRonda && Ganador == "1raCDA")
        {
            CompRonda = Ronda;
        }
        else if(Ronda != CompRonda && Ganador == "1raMordor")
        {
            CompRonda = Ronda;
        }
        else if(Ronda != CompRonda && Ganador == "2daCDA")
        {
            CompRonda = Ronda;
        }
        else if(Ronda != CompRonda && Ganador == "2daMordor")
        {
            CompRonda = Ronda;
        }
}
}