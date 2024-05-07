using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmaugSkill : MonoBehaviour
{
    public GameObject Snow;
    public GameObject FranjaSnow;
    public ClaseFranja propSnow;
    public ClaseFranja vsSnow;
    private bool eleg = false;
    private bool jugable;

    public void Skill()
    {
        if(jugable && eleg)
        {
            GameObject Card = Instantiate(FranjaSnow, new Vector2(0,0), Quaternion.identity);
            Card.transform.SetParent(Snow.transform, false);
            Card.transform.position = Snow.transform.position;
            propSnow.Climas();
            vsSnow.Climas();
        }
    }

    void Start()
    {
        Snow = GameObject.Find("VsClimateSiege");
    }

    void Update()
    {
        eleg = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        propSnow = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>();
        vsSnow = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();
    }
}