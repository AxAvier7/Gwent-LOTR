using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gestordeturnosymastallas : MonoBehaviour
{
public Text VictoriaCDA;
public Text VictoriaMordor;
public string PuntosCDA;
public string PuntosMordor;
public int Ronda = 1;
public string GanadordeRonda;
public Turnos Turnito;

public bool CDARendido;
public bool MordorRendido;
public int CDAWin = 0;
public int MordorWin = 0;
public bool FinPartida = false;
private int ManoCDA;
private int ManoMordor;
private bool CDARoboRonda1;
private bool CDARoboRonda2;
private bool CDARoboRonda3;
private bool MordorRoboRonda1; 
private bool MordorRoboRonda2;
private bool MordorRoboRonda3;
private bool yacda;
private bool yamordor;

void Awake()
{
    GanadordeRonda = "nulo";
    Turnito = GameObject.FindGameObjectWithTag("ContTurno").GetComponent<Turnos>();
}

public void yelganadores()
{
        //ronda 1
        if(Ronda == 1 && ManoCDA == 0 && ManoMordor == 0 && CDARoboRonda1 && MordorRoboRonda1 && yacda && yamordor) //se quedan sin cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "1raCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "1raMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }
    
        if(Ronda == 1 && CDARendido && MordorRendido && CDARoboRonda1 && MordorRoboRonda1 && yacda && yamordor) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "1raCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "1raMordor";
                Turnito.Turno =false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }
        if(Ronda == 1 && CDARendido && ManoMordor == 0 && CDARoboRonda1 && MordorRoboRonda1 && yacda && yamordor)  //Se rinde la Comunidad y Mordor no tiene cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "1raCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "1raMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }
        if(Ronda == 1 && ManoCDA == 0 && MordorRendido && CDARoboRonda1 && MordorRoboRonda1 && yacda && yamordor)  //Se rinde Mordor y la Comunidad no tiene cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "1raCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "1raMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
}

        //ronda 2
        if(Ronda == 2 && ManoCDA == 0 && ManoMordor == 0 && CDARoboRonda2 && MordorRoboRonda2) //se quedan sin cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "2daCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "2daMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;            
            Ronda += 1;
        }
        if(Ronda == 2 && CDARendido && MordorRendido && CDARoboRonda2 && MordorRoboRonda2) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "2daCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "2daMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }

        if(Ronda == 2 && CDARendido && MordorRendido) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "2daCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "2daMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }


        if(Ronda == 2 && CDARendido && MordorRendido && CDARoboRonda2) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "2daCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "2daMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }

        if(Ronda == 2 && CDARendido && MordorRendido && MordorRoboRonda2) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "2daCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "2daMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }

        if(Ronda == 2 && CDARendido && ManoMordor == 0 && CDARoboRonda2 && MordorRoboRonda2)  //Se rinde la Comunidad y Mordor no tiene cartas
        {
             int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "2daCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "2daMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
        }
        if(Ronda == 2 && ManoCDA == 0 && MordorRendido && CDARoboRonda2 && MordorRoboRonda2)  //Se rinde Mordor y la Comunidad no tiene cartas
        {
             int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                GanadordeRonda = "2daCDA";
                Turnito.Turno = true;
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                GanadordeRonda = "2daMordor";
                Turnito.Turno = false;
            }
            CDARendido = false;
            MordorRendido = false;
            Ronda += 1;
}
        //ronda 3
        if(Ronda == 3 && ManoCDA == 0 && ManoMordor == 0 && CDARoboRonda3 && MordorRoboRonda3) //se quedan sin cartas
        {
             int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();            
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda = 0;
        }
        if(Ronda == 3 && CDARendido && MordorRendido && CDARoboRonda3 && MordorRoboRonda3) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda = 0;
        }

        if(Ronda == 3 && CDARendido && MordorRendido && CDARoboRonda3) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda = 0;
        }

        if(Ronda == 3 && CDARendido && MordorRendido) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda = 0;
        }

        if(Ronda == 3 && CDARendido && MordorRendido && MordorRoboRonda3) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda = 0;
        }

        if(Ronda == 3 && CDARendido && ManoMordor == 0 && CDARoboRonda3 && MordorRoboRonda3)  //Se rinde la Comunidad y Mordor no tiene cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda = 0;
        }
        if(Ronda == 3 && ManoCDA == 0 && MordorRendido && CDARoboRonda3 && MordorRoboRonda3)  //Se rinde Mordor y la Comunidad no tiene cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda = 0;
        }
}
void Update()
{
    yacda = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
    yamordor = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;

    ManoCDA = GameObject.Find("Mano").GetComponent<ClaseMano>().Cartas;
    ManoMordor = GameObject.Find("Mano rival").GetComponent<ClaseMano>().Cartas;

    CDARendido = GameObject.Find("Mano").GetComponent<ClaseMano>().rendido;
    MordorRendido = GameObject.Find("Mano rival").GetComponent<ClaseMano>().rendido;
 
    PuntosCDA = GameObject.Find("contcda").GetComponent<Text>().text;
    PuntosMordor = GameObject.Find("contmordor").GetComponent<Text>().text;

    CDARoboRonda1 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
    MordorRoboRonda1 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;
    CDARoboRonda2 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo2;
    MordorRoboRonda2 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo2;
    CDARoboRonda3 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo3;
    MordorRoboRonda3 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo3;

    
//quien gana? quien sigue? tu decides
if(FinPartida == false && CDAWin == 2) //gana la Comunidad
{
    FinPartida = true;
    SceneManager.LoadScene(7);
}
else if(FinPartida == false && MordorWin == 2) //gana Mordor
{
    FinPartida = true;
    SceneManager.LoadScene(6);
}
if(FinPartida == false && CDAWin == MordorWin && MordorWin == 2) //empatan, pero gana la Comunidad porque decidi yo las reglas
{
    FinPartida = true;
    SceneManager.LoadScene(7);
}
}
}