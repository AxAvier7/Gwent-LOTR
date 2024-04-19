using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GandalfSkill : MonoBehaviour
{
    public ClaseFranja pMelee;
    public ClaseFranja pRanged;
    public ClaseFranja pSiege;
    public ClaseFranja vsMelee;
    public ClaseFranja vsRanged;
    public ClaseFranja vsSiege;
    public bool jugable;
    private bool eleg = false;

public void Skill()
{
    if(jugable && eleg)
    {
    int franja1 = pMelee.Gandalf();
    int franja2 = pRanged.Gandalf();
    int franja3 = pSiege.Gandalf();
    int franja4 = vsMelee.Gandalf();
    int franja5 = vsRanged.Gandalf();
    int franja6 = vsSiege.Gandalf();

    int cards1 = pMelee.Cartas;
    int cards2 = pRanged.Cartas;
    int cards3 = pSiege.Cartas;
    int cards4 = vsMelee.Cartas;
    int cards5 = vsRanged.Cartas;
    int cards6 = vsSiege.Cartas;

int poderpromediado = (franja1 + franja2 + franja3 + franja4 + franja5 + franja6)/(cards1 + cards2 + cards3 + cards4 + cards5 + cards6);

    pMelee.GandalfUsado(poderpromediado);
    pRanged.GandalfUsado(poderpromediado);
    pSiege.GandalfUsado(poderpromediado);
    vsMelee.GandalfUsado(poderpromediado);
    vsRanged.GandalfUsado(poderpromediado);
    vsSiege.GandalfUsado(poderpromediado);
    }
}

    void Update()
    {
      eleg = GameObject.Find("ElecMordor").GetComponent<EleccionMordor>().mordorelegido;
      jugable = gameObject.GetComponent<JugarCarta>().jugable;
      pMelee = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>();
      pRanged = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>();
      pSiege = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>();
      vsMelee = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>();
      vsRanged = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>();
      vsSiege = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();
    }
}
