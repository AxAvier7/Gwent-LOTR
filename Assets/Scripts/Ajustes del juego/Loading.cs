using UnityEngine;
using UnityEngine.UI;

public class pantalladecarga : MonoBehaviour
{
private int Rdm;
public Text Info;
private GameObject textillo;

void Start()
{
    textillo = GameObject.Find("InfoZone1");

    Rdm = Random.Range(0, 8);
    switch (Rdm)
    {
        case 0:
            Info.text = "100 de cada 100 personas mueren por muerte";
            break;
        case 1:
            Info.text = "Yo me erizo";
            break;
        case 2:
            Info.text = "Los enemigos no son tus amigos";
            break;
        case 3:
            Info.text = "Nerfeen al minero";
            break;
        case 4:
            Info.text = "Esto no es un meme, Windows 11 es una creación del diablo";
            break;
        case 5:
            Info.text = "El agua es la principal responsable de las muertes por ahogamiento";
            break;
        case 6:
            Info.text = "Casi el 100% de los ataques de tiburones a humanos se producen en el agua";
            break;
        case 7:
            Info.text = "Todas las personas que no estan vivas han tomado agua en algún momento de su vida. ¿Casualidad? Lo dudo";
            break;
        }

        Info.transform.SetParent(textillo.transform, false);
}
}