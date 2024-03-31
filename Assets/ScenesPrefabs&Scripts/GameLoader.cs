using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLoader : MonoBehaviour
{
   public void LoadGame()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(2);
   }

   public void QuitGame ()
   {
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
    SceneManager.LoadScene(6);
   }

   public void LoadLanguage()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(3);
   }

   public void LoadAudio()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(4);
   }

   public void LoadVideo()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(5);
   }

   public void LoadMainMenu()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(0);
   }

}