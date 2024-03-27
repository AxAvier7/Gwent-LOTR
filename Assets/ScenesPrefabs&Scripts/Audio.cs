using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Audio : MonoBehaviour
{
   public void LoadAudio()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(4);
    //para cargar la escena de audio
   }
}
