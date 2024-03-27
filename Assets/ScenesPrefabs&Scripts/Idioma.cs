using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Idioma : MonoBehaviour
{
   public void LoadLanguage()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(3);
        //para cargar la escena de idiomas

   }
}
