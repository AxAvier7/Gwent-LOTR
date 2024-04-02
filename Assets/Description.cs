using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDescription : MonoBehaviour
{
public Text Descripciones;
public GameObject Card;

private GameObject Descript;
private Text Informacion;

   public void Info()
   {
        Descripciones.text = Card.GetComponent<ClaseCarta>().Nombre + ". Poder: " + Card.GetComponent<ClaseCarta>().Poder.ToString() + ". Faccion: " + Card.GetComponent<ClaseCarta>().Faccion + ". Franja: " + Card.GetComponent<ClaseCarta>().Franja + ". Descripcion: " + Card.GetComponent<ClaseCarta>().Descripcion + ". Habilidad: " + Card.GetComponent<ClaseCarta>().Habilidad;
        Informacion = Instantiate(Descripciones, new Vector2(0,0), Quaternion.identity);
        Informacion.transform.SetParent(Descript.transform, false);
   }
   public void cerrarinfo()
   {
    Destroy(Informacion);
   }


   void Start()
   {
    Descript = GameObject.Find("InfoZone");
   }
}