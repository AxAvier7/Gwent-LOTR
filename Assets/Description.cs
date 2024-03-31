/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDescription : MonoBehaviour
{
    public Text descriptionText;

    private void Start()
    {
        descriptionText.enabled = false;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("InteractableObject"))
            {
                descriptionText.text = hit.collider.GetComponent<CardProperties>().description;
                descriptionText.enabled = true;
                descriptionText.transform.position = Input.mousePosition + new Vector3(20, 20, 0); // Offset the text position
            }
            else
            {
                descriptionText.enabled = false;
            }
        }
        else
        {
            descriptionText.enabled = false;
        }
    }
}
*/