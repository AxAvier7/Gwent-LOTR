using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gestordeturnosymastallas : MonoBehaviour
{
public Text VictoriaCDA; //WinsGuttsText
public Text VictoriaMordor; //WinsGriffithText
public string PuntosCDA; //PointsGutts
public string PuntosMordor; //PointsGriffith
public Text CDARobando;
public Text MordorRobando;
public int Ronda = 1;
public string Ganador; //GanadorText

public Text CDARendido; //playerRendido
public Text MordorRendido; //enemyRendido
public int CDAWin = 0; //VictoriasGutts
public int MordorWin = 0; //VictoriasGeffith
public bool FinPartida = false; //PartidaTerminada
private int ManoCDA; //Mano1
private int ManoMordor; //Mano2
private bool CDARoboRonda1; //Proba
private bool CDARoboRonda2; //Proba2
private bool CDARoboRonda3; //Proba3
private bool MordorRoboRonda1; //Eroba
private bool MordorRoboRonda2; //Eroba2
private bool MordorRoboRonda3; //Eroba3
public bool PartidaTerminada = false;

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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                 //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
            Ronda += 1;
        }
    
        if(Ronda == 1 && CDARendido && MordorRendido && CDARoboRonda1 && MordorRoboRonda1) //los dos se rinden
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
            Ronda += 1;
        }
        if(Ronda == 1 && CDARendido && ManoMordor == 0 && CDARoboRonda1 && MordorRoboRonda1)  //Se rinde la Comunidad y Mordor no tiene cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
            Ronda += 1;
        }
        if(Ronda == 1 && ManoCDA == 0 && MordorRendido && CDARoboRonda1 && MordorRoboRonda1)  //Se rinde Mordor y la Comunidad no tiene cartas
        {
            int ptsCDA = int.Parse(PuntosCDA);
            int ptsMordor = int.Parse(PuntosMordor);
            if(ptsCDA >= ptsMordor)
            {
                CDAWin += 1;
                VictoriaCDA.text = CDAWin.ToString();
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                 //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                 //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
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
                //Ganador = true// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }

            if(ptsMordor >= ptsCDA)
            {
                MordorWin += 1;
                VictoriaMordor.text = MordorWin.ToString();
                //Ganador = false// preguntar a alejandro como cambio el objeto ganador de bool a string aqui
            }
            Ronda = 0;
}
}
void Update()
{
        ManoCDA = GameObject.Find("Mano").GetComponent<ClaseMano>().Cartas;
        ManoMordor = GameObject.Find("Mano rival").GetComponent<ClaseMano>().Cartas;

        // CDARendido = GameObject.Find("Mano").GetComponent<ClaseMano>().rendido;
        // MordorRendido = GameObject.Find("Mano Rival").GetComponent<ClaseMano>().rendido;
        
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
//crear escena para cuando empaten
}

else if(FinPartida == false && CDAWin == 2)
{
FinPartida = true;
//crear escena para cuando gane CDA
}
else if(FinPartida == false && MordorWin == 2)
{
FinPartida = true;
//crear escena para cuando gane Mordor
}
}
}