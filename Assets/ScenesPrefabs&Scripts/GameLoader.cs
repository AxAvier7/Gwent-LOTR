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
    //para cargar la escena donde está el juego en sí
   }
}