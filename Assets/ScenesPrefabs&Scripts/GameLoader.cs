using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLoader : MonoBehaviour
{
   public void LoadGame()
   {
   //este y todos los metodos de este script que tiene SceneManager.LoadScene son para cargar la escene a la que corresponde el numero entre parentesis
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(2);
   }

   public void QuitGame ()
   {
      //este metodo sirve para cerrar el juego. El Debug.Log era para probar que funcionaba antes de hacer la build
      Debug.Log ("Quit");
      Application.Quit();
   }

   public void LoadSettings()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(1);
   }

   public void LoadCredits()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(5);
   }

   public void LoadAudio()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(3);
   }

   public void LoadVideo()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(4);
   }

   public void LoadMainMenu()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(0);
   }

   public void LoadTutorial()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(8);
   }

   public void LoadTutorial2()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(9);
   }
   public void LoadTutorial3()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(10);
   }

}