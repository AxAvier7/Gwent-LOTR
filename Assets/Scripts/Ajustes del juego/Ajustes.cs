using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Ajustes : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions(); 
        List<string> options = new List<string>();

        foreach (Resolution resolution in resolutions)
            {
                string option = resolution.width + "x" + resolution.height;
                options.Add(option);
            }
        resolutionDropdown.AddOptions(options);
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
