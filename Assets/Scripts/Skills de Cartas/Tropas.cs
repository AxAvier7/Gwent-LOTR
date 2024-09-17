using UnityEngine;

public class Tropas : MonoBehaviour
{
public ClaseFranja sCaC;
public ClaseFranja sR;
public ClaseFranja sS;
public ClaseFranja mCaC;
public ClaseFranja mR;
public ClaseFranja mS;
private int Poder;
public bool jugable;
public bool eleg = false;
private bool elegsauron = false;

public void Skill()
{
    if(jugable)
    {
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Rohirrim" && eleg)
        {
            Poder = sCaC.Tropillas();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Arqueros élficos" && eleg)
        {
            Poder = sR.Tropillas();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Máquinas de asedio" && eleg)
        {
            Poder = sS.Tropillas();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Uruk-Hai" && elegsauron)
        {
            Poder = mCaC.Tropillas();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Orcos arqueros" && elegsauron)
        {
            Poder = mR.Tropillas();
        }
        if(gameObject.GetComponent<ClaseCarta>().Nombre == "Olog-Hai" && elegsauron)
        {
            Poder = mS.Tropillas();
        }
        gameObject.GetComponent<ClaseCarta>().Poder = gameObject.GetComponent<ClaseCarta>().PoderInicial * Poder;
    }
}


void Update()
{
eleg = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
elegsauron = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
jugable = gameObject.GetComponent<JugarCarta>().jugable;
sCaC = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
sR = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>();
sS = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>();
mCaC = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>();
mR = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>();
mS = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();
}
}