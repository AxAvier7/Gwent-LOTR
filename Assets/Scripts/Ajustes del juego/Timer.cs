using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
[SerializeField]
private int tiempillo = 0;

public void Update()
{
    if (tiempillo < 5000)
    {
        tiempillo ++;
        if(tiempillo == 5000)
        {
            SceneManager.LoadScene(2);
        }
    }
}
}
