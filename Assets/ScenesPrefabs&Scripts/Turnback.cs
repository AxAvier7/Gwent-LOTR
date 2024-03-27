using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VolverMenu : MonoBehaviour
{
   public void LoadMainMenu()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(0);
        //para regresar a la escena de la pantalla de inicio

   }
}