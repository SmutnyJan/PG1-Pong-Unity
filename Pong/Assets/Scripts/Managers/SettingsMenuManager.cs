using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    public Slider SoundsVolumeSlider;
    public Slider SoundtrackVolumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundsVolumeSlider.value = SettingsManager.Instance.CurrentSettings.SoundVolume;
        SoundtrackVolumeSlider.value = SettingsManager.Instance.CurrentSettings.SoundtrackVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSoundsVolumeSliderChanged()
    {
        SoundManager.Instance.AudioSourceSounds.volume = SoundsVolumeSlider.value;
    }


    public void OnSoundtrackVolumeSliderChanged()
    {
        SoundManager.Instance.AudioSourceSoundstrack.volume = SoundtrackVolumeSlider.value;
    }


    public void Save()
    {
        SoundManager.Instance.PlayRandomSoundFromCategory(SoundManager.SoundCategory.Click);
        SettingsManager.Instance.Save(new SettingsManager.SaveSettings { SoundVolume = SoundsVolumeSlider.value, SoundtrackVolume = SoundtrackVolumeSlider.value});
        SettingsManager.Instance.SetGameSettingsDependencies();
    }
}
