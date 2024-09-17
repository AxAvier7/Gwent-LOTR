using UnityEngine;
using UnityEngine.UI;

public class CardSender : MonoBehaviour
{
    public Button enviarCartasButton;
    void Start()
    {
        if (enviarCartasButton != null)
        {
            enviarCartasButton.onClick.AddListener(EnviarCartas);
        }
        else
        {
            Debug.LogError("El botón 'Enviar Cartas' no está asignado.");
        }
    }

    public void EnviarCartas()
    {
        CardManager.Instance.TransferCardsToDecks();
        Debug.Log("Cartas transferidas a los mazos.");
    }
}
