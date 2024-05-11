using UnityEngine;
using UnityEngine.UI;

public class pantalladecarga : MonoBehaviour
{
private int Rdm;
public Text Info;
private GameObject textillo;
private Text Information;

void Awake()
{
    Rdm = Random.Range(0, 10);
    Debug.Log(Rdm);
    if(Rdm == 0)
    {
        Info.text = "100 de cada 100 personas mueren por muerte";
    }
    if(Rdm == 1)
    {
        Info.text = "Yo me erizo";
    }
    if(Rdm == 2)
    {
        Info.text = "Los enemigos no son tus amigos";
    }
    if(Rdm == 3)
    {
        Info.text = "Nerfeen al minero";
    }
    if(Rdm == 4)
    {
        Info.text = "Esto no es un meme, Windows 11 es una creación del diablo";
    }
    if(Rdm == 5)
    {
        Info.text = "Pero la quería tanto...";
    }
    if(Rdm == 6)
    {
        Info.text = "Se me jodió la tecla de Windows y tuve que asignársela a un botón del mouse, gracias por nada HP Victus";
    }
    if(Rdm == 7)
    {
        Info.text = "El agua es la principal responsable de las muertes por ahogamiento";
    }
    if(Rdm == 8)
    {
        Info.text = "Casi el 100% de los ataques de tiburones a humanos se producen en el agua";
    }
    if(Rdm == 9)
    {
        Info.text = "Todas las personas que no estan vivas han tomado agua en algun momento de su vida. Casualidad? Lo dudo";
    }
    Information = Instantiate(Info, new Vector2(0,0), Quaternion.identity);
    Information.transform.SetParent(textillo.transform, false);
    return;
}

public void Start()
{
    textillo = GameObject.Find("InfoZone1");
}
}