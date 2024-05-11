using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
public Sound[] sonidos; //array con todos los sonidos del juego
public static AudioManager instance;

void Awake() //void para que el audio corra al momento de iniciarse el juego
{
    if (instance == null) //revisa ya esta instanciada la pista de audio
    instance = this; //si no esta instanciada, la instancia
    else
    {
        Destroy(gameObject); //si ya esta instanciada, la destruye para que se instancia una sola vez
        return;
    }

    DontDestroyOnLoad(gameObject); //esto es para que el audio de fondo no deje de sonar con el cambio de escena
    
    foreach (Sound s in sonidos)
    {
        s.source = gameObject.AddComponent<AudioSource>(); //para anadir el componente de audio a un gameobject y guardar este componente como variable
        //todos estos que vienen ahora son para asignarle a cada gameobject que tenga asignado el audio source, las caracteristicas de cada pista de audio
        s.source.clip = s.clip; 
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;
    }
}   

 void Start()
{
    Play("Musica de fondo"); //el script busca el asset con ese nombre (que es un audio)
}

public void Play (string name)
{
    Sound s = Array.Find(sonidos, Sound => Sound.nombre == name); //busca si hay algun audio dentro del array de audios con el nombre del audio asignado al objeto
    if (s == null)
    return; //si no lo encuentra simplemente no reproduce nada xd
    s.source.Play(); //aqui si que reproduce el sonido
}
}