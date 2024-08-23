using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
[SerializeField]
private float ObjTime = 5f;
private float CurrTime = 0f;

public void Update()
{
    CurrTime += Time.deltaTime;
    if(CurrTime >= ObjTime)
    {
        SceneManager.LoadScene(2);
    }
}
}