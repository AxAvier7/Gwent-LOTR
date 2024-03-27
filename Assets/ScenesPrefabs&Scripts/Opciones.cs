using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Opciones : MonoBehaviour
{
   public void LoadSettings()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(1);
        //para cargar la escena de los ajustes

   }
}
