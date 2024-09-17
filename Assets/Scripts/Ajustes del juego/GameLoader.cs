using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
public void LoadGame()
{
//este y todos los metodos de este script que tiene SceneManager.LoadScene son para cargar la escene a la que corresponde el numero entre parentesis
SceneManager.LoadScene(2);
}

public void QuitGame ()
{
   //este metodo sirve para cerrar el juego.
   Application.Quit();
}

public void LoadSettings()
{
   SceneManager.LoadScene(1);
}

public void LoadCredits()
{
   SceneManager.LoadScene(5);
}

public void LoadAudio()
{
   SceneManager.LoadScene(3);
}

public void LoadVideo()
{
   SceneManager.LoadScene(4);
}

public void LoadMainMenu()
{
   SceneManager.LoadScene(0);
}

public void LoadTutorial()
{
   SceneManager.LoadScene(8);
}

// public void LoadTutorial2()
// {
//    SceneManager.LoadScene(9);
// }
public void LoadTutorial3()
{
   SceneManager.LoadScene(9);
}
public void LoadLoader()
{
   SceneManager.LoadScene(10);
}
public void LoadCreator()
{
   SceneManager.LoadScene(11);
}

void Update()
{
   if(Input.GetKeyDown(KeyCode.Backspace) && SceneManager.GetActiveScene().buildIndex != 11)
   {
      LoadMainMenu();
   }
}
}