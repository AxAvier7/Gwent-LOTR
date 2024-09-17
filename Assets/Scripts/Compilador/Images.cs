using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    public GameObject Carta;

    public void Image()
    {
        Sprite cartaSprite = gameObject.GetComponent<Image>().sprite;
        Carta.GetComponent<Image>().sprite = cartaSprite;

        // Asigna la imagen al componente BaseCard de la carta
        BaseCard baseCard = Carta.GetComponent<BaseCard>();
        if (baseCard != null)
        {
            baseCard.SetCardImage(cartaSprite);
        }
        else
        {
            Debug.LogError("No se encontró el componente BaseCard en la carta.");
        }
    }
}
