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
    public bool skillsauron;
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
 public void EmpCDA()
 {
    Turno = true;
 }

  public void EmpMordor()
 {
    Turno = false;
 }

void Update()
{
eligearagorn = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
eligesauron =GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
Ganador = GameObject.Find("CalcGanador").GetComponent<Gestordeturnosymastallas>().GanadordeRonda;
skillsauron = GameObject.Find("Sauron").GetComponent<SkillSauron>().used;

ManoCDA = GameObject.FindGameObjectWithTag("Manojugador").GetComponent<ClaseMano>();
ManoMordor = GameObject.FindGameObjectWithTag("Manomordor").GetComponent<ClaseMano>();

CDARoboRonda1 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
CDARoboRonda2 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo2;
CDARoboRonda3 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo3;
MordorRoboRonda1 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;
MordorRoboRonda2 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo2;
MordorRoboRonda3 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo3;

Ronda = GameObject.Find("CalcGanador").GetComponent<Gestordeturnosymastallas>().Ronda;
Mano1 = GameObject.Find("Mano").GetComponent<ClaseMano>().Cartas;
Mano2 = GameObject.Find("Mano rival").GetComponent<ClaseMano>().Cartas;

        if(Turno == false && skillsauron && sauron == 1 && eligesauron) //cambia el turno cuando Sauron use su habilidad
        {
            sauron += 1;
            Turno = true;
        }


       if(Turno) //cambio de turno 
       {
        taparmanoCDA.sizeDelta = new Vector2(0, 0);
        taparmanomordor.sizeDelta = new Vector2(1300, 170);
        if(Mano1 == 0 && Ronda == 1 && CDARoboRonda1 && eligearagorn)
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

        if(comparador1 != Mano1 && eligearagorn)
        {
            comparador1 = Mano1;
            Turno = false;
        }
       }


       if(Turno == false)
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
        
        //los 3 que vienen son para que cuando se rinda alguien se tapen la mano del otro
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
            EmpCDA();
        }
        else if(Ronda != CompRonda && Ganador == "1raMordor")
        {
            CompRonda = Ronda;
            EmpMordor();
        }
        else if(Ronda != CompRonda && Ganador == "2daCDA")
        {
            CompRonda = Ronda;
            EmpCDA();
        }
        else if(Ronda != CompRonda && Ganador == "2daMordor")
        {
            CompRonda = Ronda;
            EmpMordor();
        }
}
}