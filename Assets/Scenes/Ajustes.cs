using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Ajustes : MonoBehaviour
{
Resolution[] resolutions;
public Dropdown resolutionDropdown;
void Start()
{
    resolutions = Screen.resolutions;
    resolutionDropdown.ClearOptions(); 
    List<string> options = new List<string>();

for (int i = 0; i < resolutions.Length; i++)
{
    string option = resolutions[i].width + "x" + resolutions[i].height;
    options.Add(option);
}
resolutionDropdown.AddOptions(options);
}

public AudioMixer audioMixer;
public void SetVolume (float volume)
{
    audioMixer.SetFloat("Volume", volume);
}

public void Calidad (int defcalidad)
{
    QualitySettings.SetQualityLevel(defcalidad);
}

public void Pantallacompleta (bool isFullScreen)
{
    Debug.Log ("pantcomp");
    Screen.fullScreen = isFullScreen;
}
}
