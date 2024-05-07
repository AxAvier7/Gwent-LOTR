using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasoescena : MonoBehaviour
{
    [SerializeField]
    private float delay = 720f;
    [SerializeField]
    private float tiempillo;

    void Update()
    {
        tiempillo += 1f;
        if (tiempillo  > delay)
        {
            SceneManager.LoadScene(2);
        }
    }
}
