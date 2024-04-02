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

   public void InfoCard()
   {
        Descripciones.text = Card.GetComponent<ClaseCarta>().Nombre + ". Poder: " + Card.GetComponent<ClaseCarta>().Poder.ToString() + ". Faccion: " + Card.GetComponent<ClaseCarta>().Faccion + ". Franja: " + Card.GetComponent<ClaseCarta>().Franja + ". Descripcion: " + Card.GetComponent<ClaseCarta>().Descripcion + ". Habilidad: " + Card.GetComponent<ClaseCarta>().Habilidad;
        Informacion = Instantiate(Descripciones, new Vector2(0,0), Quaternion.identity);
        Informacion.transform.SetParent(Descript.transform, false);
   }
   public void InfoClimate()
   {
        Descripciones.text = Card.GetComponent<ClaseClima>().Nombre + ". Faccion: " + Card.GetComponent<ClaseClima>().Faccion + ". Franja afectada: " + Card.GetComponent<ClaseClima>().Franja_afectada + ". Descripcion: " + Card.GetComponent<ClaseClima>().Descripcion + ". Habilidad: " + Card.GetComponent<ClaseClima>().Habilidad;
        Informacion = Instantiate(Descripciones, new Vector2(0,0), Quaternion.identity);
        Informacion.transform.SetParent(Descript.transform, false);
   }

    public void InfoLeader()
   {
        Descripciones.text = Card.GetComponent<ClaseLider>().Nombre + ". Faccion: " + Card.GetComponent<ClaseLider>().Faccion + ". Descripcion: " + Card.GetComponent<ClaseLider>().Descripcion + ". Habilidad: " + Card.GetComponent<ClaseLider>().Habilidad;
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