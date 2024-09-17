using UnityEngine;
using UnityEngine.UI;

public class ConfirmDescription : MonoBehaviour
{
    public InputField descInputField;

    public BaseCard cardPrototype;

    public Button confirmButton;

    private void Start()
    {
        confirmButton.onClick.AddListener(ConfirmDescriptionInput);
    }

    public void ConfirmDescriptionInput()
    {
        if (cardPrototype != null && descInputField != null)
        {
            cardPrototype.Description = descInputField.text;

            Debug.Log("Descripción confirmada: " + cardPrototype.Description);
        }
        else
        {
            Debug.LogWarning("CardPrototype o InputField no asignado.");
        }
    }
}