using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject MenuPausaUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (JuegoPausado)
    {
        Continuar();
    }
    else
    {
        Pausar();
    }
    }
    }
    public void Continuar()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;

    }
    void Pausar()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }
}
