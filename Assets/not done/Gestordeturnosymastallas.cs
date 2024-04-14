using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gestordeturnosymastallas : MonoBehaviour
{
public Text VictoriaCDA;
public Text VictoriaMordor;
public string PuntosCDA;
public string PuntosMordor;
public Text CDARobando;
public Text MordorRobando;
public int Ronda = 1;
public Text Ganador;

public Text CDARendido;
public Text MordorRendido;
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

public void yelganadores()
{
        //ronda 1
        if(Ronda == 1 && ManoCDA == 0 && ManoMordor == 0 && CDARoboRonda1 && MordorRoboRonda1) //se quedan sin cartas
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
        }
        if(Ronda == 1 && CDARendido && MordorRendido && CDARoboRonda1 && MordorRoboRonda1) //los dos se rinden
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
        }
        if(Ronda == 1 && CDARendido && ManoMordor == 0 && CDARoboRonda1 && MordorRoboRonda1)  //Se rinde la Comunidad y Mordor no tiene cartas
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
        }
        if(Ronda == 1 && ManoCDA == 0 && MordorRendido && CDARoboRonda1 && MordorRoboRonda1)  //Se rinde Mordor y la Comunidad no tiene cartas
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
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
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
            }
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
        }
        if(Ronda == 2 && CDARendido && MordorRendido && CDARoboRonda2 && MordorRoboRonda2) //los dos se rinden
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
        }
        if(Ronda == 2 && CDARendido && ManoMordor == 0 && CDARoboRonda2 && MordorRoboRonda2)  //Se rinde la Comunidad y Mordor no tiene cartas
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
        }
        if(Ronda == 2 && ManoCDA == 0 && MordorRendido && CDARoboRonda2 && MordorRoboRonda2)  //Se rinde Mordor y la Comunidad no tiene cartas
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
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
            Ronda += 1;
            CDARobando.text = "";
            MordorRobando.text = "";
}

/*void Update()
{
        ManoCDA = GameObject.Find("Mano").GetComponent<ClaseMano>().Cartas;
        ManoMordor = GameObject.Find("Mano rival").GetComponent<ClaseMano>().Cartas;

        CDARendido = GameObject.Find("Mano").GetComponent<ClaseMano>().rendido;
        MordorRendido = GameObject.Find("Mano Rival").GetComponent<ClaseMano>().rendido;
        
        PuntosCDA = GameObject.Find("ContCDA").GetComponent<Text>().text;
        PuntosMordor = GameObject.Find("ContMordor").GetComponent<Text>().text;

        CDARoboRonda1 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo1;
        MordorRoboRonda1 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo1;
        CDARoboRonda2 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo2;
        MordorRoboRonda2 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo2;
        CDARoboRonda3 = GameObject.Find("Mazo CDA").GetComponent<RobarCDA>().robo3;
        MordorRoboRonda3 = GameObject.Find("Mazo Mordor").GetComponent<RobarMordor>().robo3;

    
//quien gana? quien sigue? tu decides
if(FinPartida == false && CDAWin == MordorWin && MordorWin == 2)
{
FinPartida = true;
Ganador.text = "Ni pa ti ni pa mi";
}

else if(FinPartida == false && CDAWin == 2)
{
FinPartida = true;
Ganador.text = "Gana el bien";
}

else if(FinPartida == false && MordorWin == 2)
{
FinPartida = true;
Ganador.text = "Gana el mal";
}
}
*/
}
}