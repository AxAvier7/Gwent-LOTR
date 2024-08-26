using UnityEngine;

public class Zkillz : MonoBehaviour
{
public ClaseFranja Mprop; //Franja Melee Propia
public ClaseFranja Rprop; //Franja Ranged Propia
public ClaseFranja Sprop; //Franja Siege Propia
public ClaseFranja Mvs; //Franja Melee Rival
public ClaseFranja Rvs; //Franja Ranged Rival
public ClaseFranja Svs; //Franja Siege Rival

public FranjaClima ClimageMelee; //Clima Melees Propio
public FranjaClima ClimageRanged; //Clima Ranged Propio
public FranjaClima ClimageSiege; //Clima Siege Propio

public FranjaClima ClimageMeleeVS; //Clima Melee Rival
public FranjaClima ClimageRangedVS; //Clima Ranged Rival
public FranjaClima ClimageSiegeVS; //Clima Siege Rival


private GameObject CDACem;
private GameObject MordorCem;

public GameObject CuernoGondor;
public GameObject Nieve;

public bool jugable;
private bool elegMordor = false;
private bool elegCDA = false;
public bool Turn;
public bool SauronPlayed = false;

#region Habilidades
public void Horn_n_Ring() //Habilidad de cartas aumento
{
    if(jugable && elegCDA && elegMordor && gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
    {
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 4)
        {
            Mprop.Aumento();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 5)
        {
            Rprop.Aumento();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 6)
        {
            Sprop.Aumento();
        }
    }
    else if(jugable && elegCDA && elegMordor && gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
    {
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 4)
        {
            Mvs.Aumento();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 5)
        {
            Rvs.Aumento();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 6)
        {
            Svs.Aumento();
        }
    }
}

public void Clima() //Habilidad de los climas
{
    if(jugable && elegCDA && elegMordor)
    {
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 4)
        {
            Mprop.Climas();
            Mvs.Climas();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 5)
        {
            Rprop.Climas();
            Rvs.Climas();
        }
        if(gameObject.GetComponent<ClaseCarta>().Franjita == 6)
        {
            Sprop.Climas();
            Svs.Climas();
        }
    }
}

public void Despejee() //Habilidad Despeje 1/2
{
    if(jugable && elegCDA && elegMordor)
    {
        Mprop.Despeje();
        Mvs.Despeje();
        Rprop.Despeje();
        Rvs.Despeje();
        Sprop.Despeje();
        Svs.Despeje();
        PalCementerio();
    }
}

public void PalCementerio() //Habilidad Despeje 2/2
{
    foreach(GameObject Card in ClimageMelee.CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Niebla")
        {Card.transform.SetParent(CDACem.transform, false);
        Card.transform.position = CDACem.transform.position;}
    }
    foreach(GameObject Card in ClimageRanged.CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Lluvia")
        {Card.transform.SetParent(CDACem.transform, false);
        Card.transform.position = CDACem.transform.position;}
    }
    foreach(GameObject Card in ClimageSiege.CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Nevada")
        {Card.transform.SetParent(CDACem.transform, false);
        Card.transform.position = CDACem.transform.position;}
    }
    foreach(GameObject Card in ClimageMeleeVS.CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Niebla")
        {Card.transform.SetParent(MordorCem.transform, false);
        Card.transform.position = MordorCem.transform.position;}
    }
    foreach(GameObject Card in ClimageRangedVS.CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Lluvia")
        {Card.transform.SetParent(MordorCem.transform, false);
        Card.transform.position = MordorCem.transform.position;}
    }
    foreach(GameObject Card in ClimageSiegeVS.CartasenFranja)
    {
        if(Card.GetComponent<ClaseCarta>().Nombre == "Nevada")
        {Card.transform.SetParent(MordorCem.transform, false);
        Card.transform.position = MordorCem.transform.position;}
    }

    if(gameObject.GetComponent<ClaseCarta>().Faccion == "Comunidad del Anillo")
    {
        gameObject.transform.position = CDACem.transform.position;
        gameObject.transform.SetParent(CDACem.transform, true);
    }
    if(gameObject.GetComponent<ClaseCarta>().Faccion == "Mordor")
    {
        gameObject.transform.position = MordorCem.transform.position;
        gameObject.transform.SetParent(MordorCem.transform, true);
    }
}

public void Galadriell() //Habilidad de Galadriel
{
    if(jugable && elegCDA)
    {
        GameObject Card = Instantiate(CuernoGondor, new Vector2(0,0), Quaternion.identity);
        Card.transform.SetParent(ClimageRanged.transform, false);
        Card.transform.position = ClimageRanged.transform.position;
        Rprop.Aumento();
    }
}

public void Balrogg() //Habilidad del Balrog
{
    if(jugable && elegMordor)
    {
        int melee = Mprop.CartasenFranja.Count;
        int ranged = Rprop.CartasenFranja.Count;
        int siege = Sprop.CartasenFranja.Count;
        int menor;

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
                Mprop.Balrog(menor);
                return;
            }
            if(ranged == menor)
            {
                Rprop.Balrog(menor);
                return;
            }
            if(siege == menor)
            {
                Sprop.Balrog(menor);
                return;
            }
        }
    }
}

public void Legolass() //Habilidad de Legolas
{
    if(jugable && elegMordor)
    {
        Rvs.Legolas();
    }
}

public void Samugg() //Habilidad de Smaug
{
    if(jugable && elegMordor)
    {
        GameObject Card = Instantiate(Nieve, new Vector2(0,0), Quaternion.identity);
        Card.transform.SetParent(ClimageSiegeVS.transform, false);
        Card.transform.position = ClimageSiegeVS.transform.position;
        Sprop.Climas();
        Svs.Climas();
    }
}

public void Gandulfo() //Habilidad de Gandalf
{
    if(jugable && elegMordor)
    {
        int franja1 = Mprop.Gandalf();
        int franja2 = Rprop.Gandalf();
        int franja3 = Sprop.Gandalf();
        int franja4 = Mvs.Gandalf();
        int franja5 = Rvs.Gandalf();
        int franja6 = Svs.Gandalf();

        int cards1 = Mprop.Cartas;
        int cards2 = Rprop.Cartas;
        int cards3 = Sprop.Cartas;
        int cards4 = Mvs.Cartas;
        int cards5 = Rvs.Cartas;
        int cards6 = Svs.Cartas;
        int poderpromediado = (franja1 + franja2 + franja3 + franja4 + franja5 + franja6)/(cards1 + cards2 + cards3 + cards4 + cards5 + cards6);

        Mprop.GandalfUsado(poderpromediado);
        Rprop.GandalfUsado(poderpromediado);
        Sprop.GandalfUsado(poderpromediado);
        Mvs.GandalfUsado(poderpromediado);
        Rvs.GandalfUsado(poderpromediado);
        Svs.GandalfUsado(poderpromediado);
    }
}

#endregion Habilidades

void Update()
{
    Mprop = GameObject.FindGameObjectWithTag("CDAMelee").GetComponent<ClaseFranja>(); 
    Rprop = GameObject.FindGameObjectWithTag("CDARanged").GetComponent<ClaseFranja>(); 
    Sprop = GameObject.FindGameObjectWithTag("CDASiege").GetComponent<ClaseFranja>(); 
    Mvs = GameObject.FindGameObjectWithTag("MordorMelee").GetComponent<ClaseFranja>(); 
    Rvs = GameObject.FindGameObjectWithTag("MordorRanged").GetComponent<ClaseFranja>(); 
    Svs = GameObject.FindGameObjectWithTag("MordorSiege").GetComponent<ClaseFranja>();  
    
    ClimageMelee = GameObject.FindGameObjectWithTag("CMCDA").GetComponent<FranjaClima>();
    ClimageRanged = GameObject.FindGameObjectWithTag("CRCDA").GetComponent<FranjaClima>(); 
    ClimageSiege = GameObject.FindGameObjectWithTag("CSCDA").GetComponent<FranjaClima>(); 
    ClimageMeleeVS = GameObject.FindGameObjectWithTag("CMMORDOR").GetComponent<FranjaClima>(); 
    ClimageRangedVS = GameObject.FindGameObjectWithTag("CRMORDOR").GetComponent<FranjaClima>(); 
    ClimageSiegeVS = GameObject.FindGameObjectWithTag("CSMORDOR").GetComponent<FranjaClima>();

    jugable = gameObject.GetComponent<JugarCarta>().jugable;
    elegMordor = GameObject.Find("ElecMordor").GetComponent<Eleccion>().mordorelegido;
    elegCDA = GameObject.Find("ElecCDA").GetComponent<Eleccion>().cdaelegido;
    CDACem = GameObject.Find("Graveyard CDA");
    MordorCem = GameObject.Find("Graveyard Mordor");
    Turn = GameObject.Find("GestTurno").GetComponent<Turnos>().Turno;
}
}