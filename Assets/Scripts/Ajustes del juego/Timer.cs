using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
[SerializeField]
private int tiempillo = 0;

public void Update()
{
    if (tiempillo < 10000)
    {
        tiempillo ++;
        if(tiempillo == 10000)
        {
            SceneManager.LoadScene(2);
        }
    }
}
}
