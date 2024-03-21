using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robar : MonoBehaviour
{
public GameObject GondorWarrior1;
public GameObject GondorWarrior2;
public GameObject GondorWarrior3;
public GameObject ElficArcher1;


public GameObject  Mano;

public void OnClick()
{
    for(int i = 0; i < 5; i++)
{
GameObject Card = Instantiate(GondorWarrior1, new Vector2(0,0), Quaternion.identity);
Card.transform.SetParent(Mano.transform, false);
}
}
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
