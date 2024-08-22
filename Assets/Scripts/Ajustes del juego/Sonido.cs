using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
public string nombre;
public AudioClip clip;
[Range(0f, 1f)] //rango de audio de cada pista de audio
public float volume; //este es el volumen del audio
[Range(.1f, 3f)] //rango de la tonalidad  del audio
public float pitch; //esta es la tonalidad del audio

[HideInInspector] //esto de aca oculta cada audio que asignemos al inspector de Unity
public AudioSource source;
public bool loop;
}