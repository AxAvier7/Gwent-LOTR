using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turnos : MonoBehaviour
{
    public int Ronda = 1;
    public bool Turno = true;
    public ClaseMano ManoCDA; //playerhand
    public ClaseMano ManoMordor; //enemyhand
    public GameObject TaparManoCDA; //Bloqueo1
    public GameObject TaparManoMordor; //Bloqueo2
    public Text CDARendido; //guttsrendidotext
    public Text MordorRendido; //griffithrendidotext
    public bool skillaragorn; //guttsusado
    public bool skillsauron; //griffithusado
    private int aragorn = 1; //gutts
    private int sauron = 1; //griffith
    private int Mano1 = 0;
    private int Mano2 = 0;
    private int comparador1 = 0;
    private int comparador2 = 0;
    private RectTransform taparmanoCDA; //bloqueo1
    private RectTransform taparmanomordor; //bloqueo2

    private bool CDARoboRonda1;
    private bool CDARoboRonda2;
    private bool CDARoboRonda3;
    private bool MordorRoboRonda1;
    private bool MordorRoboRonda2;
    private bool MordorRoboRonda3;

void Start()
{
taparmanoCDA = TaparManoCDA.GetComponent<RectTransform>();
taparmanomordor = TaparManoMordor.GetComponent<RectTransform>();
}

}