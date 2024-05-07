using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pantalladecarga : MonoBehaviour
{
public float Rdm = 0f;
public Text Info;
private GameObject textillo;
private Text Information;

void Awake()
{
    Rdm = Random.Range(10, 17);
    Debug.Log(Rdm);
    if(Rdm == 10)
    {
        Info.text = "100 de cada 100 personas mueren por muerte";
        Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(textillo.transform, false);
        return;
    }
    if(Rdm == 11)
    {
        Info.text = "Yo me erizo";
        Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(textillo.transform, false);
        return;
    }
    if(Rdm == 12)
    {
        Info.text = "Los enemigos no son tus amigos";
        Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(textillo.transform, false);
        return;
    }
    if(Rdm == 13)
    {
        Info.text = "Nerfeen al minero";
        Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(textillo.transform, false);
        return;
    }
    if(Rdm == 14)
    {
        Info.text = "Esto no es un meme, Windows 11 es una creación del diablo";
        Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(textillo.transform, false);
        return;
    }
    if(Rdm == 15)
    {
        Info.text = "Pero la quería tanto...";
        Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(textillo.transform, false);
        return;
    }
    if(Rdm == 16)
    {
        Info.text = "Se me jodió la tecla de Windows y tuve que asignársela a un botón del mouse, gracias por nada HP Victus";
        Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(textillo.transform, false);
        return;
    }
}

public void Start()
{
    textillo = GameObject.Find("Informationxd");
}
}