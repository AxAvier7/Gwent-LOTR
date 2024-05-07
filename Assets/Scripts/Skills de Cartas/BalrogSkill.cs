using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalrogSkill : MonoBehaviour
{
public bool jugable;
private bool eleg = false;
public ClaseFranja CDAMelee;
public ClaseFranja CDARanged;
public ClaseFranja CDASiege;

public void Skill()
{
    if(jugable && eleg)
    {
        int melee = CDAMelee.CartasenFranja.Count;
        int ranged = CDARanged.CartasenFranja.Count;
        int siege = CDASiege.CartasenFranja.Count;
        int menor = 0;

        if(melee != 0 && (ranged == 0 || melee <= ranged) && (siege == 0 || melee <= siege))
        {
            menor = melee;
        }
        else if(ranged != 0 && (melee == 0 || ranged <= melee) && (siege == 0 || ranged <= siege))
        {
            menor = ranged;
        }
        else
        {
            menor = siege;
        }

    if(menor < 10 && menor != 0)
    {
        if(melee == menor)
        {
            CDAMelee.Balrog(menor);
            return;
        }
        if(ranged == menor)
        {
            CDARanged.Balrog(menor);
            return;
        }
        if(siege == menor)
        {
            CDASiege.Balrog(menor);
            return;
        }
    }
}
}

    void Update()
    {
        eleg = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        CDAMelee = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>(); 
        CDARanged = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>(); 
        CDASiege = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
    }
}