using UnityEngine;
using UnityEngine.UI;
public class VolumeBar : MonoBehaviour
{ 
    [SerializeField] Slider VolumeSlider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
    }

    public void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }
}