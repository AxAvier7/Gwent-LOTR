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
    public bool skillaragorn;
    public bool skillsauron;
    private int aragorn = 1;
    private int sauron = 1;
    private int Mano1 = 0;
    private int Mano2 = 0;
    private int comparador1 = 0;
    private int comparador2 = 0;
    private RectTransform taparmanoCDA; //bloqueo1
    private RectTransform taparmanomordor; //bloqueo2

    private bool CDARoboRonda1; //Eroba
    private bool CDARoboRonda2; //Eroba2
    private bool CDARoboRonda3; //Eroba3
    private bool MordorRoboRonda1; //Proba
    private bool MordorRoboRonda2; //Proba2
    private bool MordorRoboRonda3; //Proba3

    public string Ganador;
    private int gestronda = 2; //rondita

void Start()
{
Ganador = "";
taparmanoCDA = TaparManoCDA.GetComponent<RectTransform>();
taparmanomordor = TaparManoMordor.GetComponent<RectTransform>();
}


void Update()
{
Ganador = GameObject.Find("GameManager").GetComponent<Gestordeturnosymastallas>().Ganador;

// skillaragorn = GameObject.Find("Aragorn").GetComponent<GuttsHabilidad>().Utilizada;
// skillsauron = GameObject.Find("Sauron").GetComponent<GriffithHabilidad>().Utilizada;

ManoCDA = GameObject.FindGameObjectWithTag("manojugador").GetComponent<ClaseMano>();
ManoMordor = GameObject.FindGameObjectWithTag("manomordor").GetComponent<ClaseMano>();

CDARoboRonda1 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
CDARoboRonda2 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo2;
CDARoboRonda3 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo3;
MordorRoboRonda1 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;
MordorRoboRonda2 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo2;
MordorRoboRonda3 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo3;

Ronda = GameObject.Find("GameManager").GetComponent<Gestordeturnosymastallas>().Ronda;
Mano1 = GameObject.Find("Mano").GetComponent<ClaseMano>().Cartas;
Mano2 = GameObject.Find("Mano rival").GetComponent<ClaseMano>().Cartas;



        if(Ronda == gestronda && Ganador == "Gano CDA")
        {
            gestronda +=1;
            Turno = true;
        }
        else if(Ronda == gestronda && Ganador == "Gano Mordor")
        {
            gestronda +=1;
            Turno = false;
        }
        else if(Ronda == gestronda && Ganador == "Gano CDA la 2da ronda")
        {
            gestronda +=1;
            Turno = true;
        }
        else if(Ronda == gestronda && Ganador == "Gano Mordor la 2da ronda")
        {
            gestronda +=1;
            Turno = false;
        }

        if(Turno && skillaragorn && aragorn == 1) // cambiando el turno cuando se usen las habilidades de jefe
        {
            aragorn += 1;
            Turno = false;
        }
        if(Turno == false && skillsauron && sauron == 1)
        {
            sauron += 1;
            Turno = true;
        }


       if(Turno) //cambio de turno 
       {
        taparmanomordor.sizeDelta = new Vector2(0, 0);
        taparmanoCDA.sizeDelta = new Vector2(550, 55);
        if(Mano1 == 0 && Ronda == 1 && CDARoboRonda1) //esto es para cuando te quedes sin cartas le toque solo al oponente
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 2 && CDARoboRonda2)
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 3 && CDARoboRonda3)
        {
            Turno = false;
        }

        if(comparador1 != Mano1)
        {
            comparador1 = Mano1;
            Turno = false;
        }
       }


       if(Turno == false) //cambio de turno
       {
        taparmanoCDA.sizeDelta = new Vector2(0, 0);
        taparmanomordor.sizeDelta = new Vector2(550, 55);
        if(Mano2 == 0 && Ronda == 1 && MordorRoboRonda1)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 2 && MordorRoboRonda2)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 3 && MordorRoboRonda3)
        {
            Turno = true;
        }

        if(comparador2 != Mano2)
        {
            comparador2 = Mano2;
            Turno = true;
        }
       }

       if(ManoCDA.rendido) //cuando el jugador se rinda siempre le toca al oponente y aparece el cartel de rendido
        {
            Turno = false;
            CDARendidotxt.text = "La Comunidad Se Ha Rendido";
        }
        else
        {
            CDARendidotxt.text = "";
        }

        if(ManoMordor.rendido)
        {
            Turno = true;
            MordorRendidotxt.text = "Mordor Se Ha Rendido";
        }
        else
        {
            MordorRendidotxt.text = "";
        }
        
        if(ManoMordor.rendido && ManoCDA.rendido) //cuando se rinden ambos no se pueden ver las cartas de ninguna mano
        {
            taparmanomordor.sizeDelta = new Vector2(550, 55);
            taparmanoCDA.sizeDelta = new Vector2(550, 55);
        }

}
}