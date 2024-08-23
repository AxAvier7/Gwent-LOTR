using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    //este script es para llamar al menu de pausa mientras se esta jugando
    public static bool JuegoPausado = false;
    public GameObject MenuPausaUI;

    void Update() //el menu se llama cuando se usa la tecla escape
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado) //si el juego ya estaba pausado, cierra el menu
            {
                Continuar();
            }
            else //en cualquier otro caso, abre el menu
            {
                Pausar();
            }
        }
    }

    public void Continuar() //hace que continue el juego, cerrando el menu y ocultandolo al usuario
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    void Pausar() //abre el menu de pausa y detiene el tiempo
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }
}