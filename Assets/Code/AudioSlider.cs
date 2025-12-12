using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    [Header("UI Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider atmoSlider;

    void Start()
    {
        InitSlider(masterSlider, "MasterVol", "Master");
        InitSlider(musicSlider, "MusicVol", "Music");
        InitSlider(sfxSlider, "SFXVol", "SFX");
        InitSlider(atmoSlider, "AtmoVol", "Atmo");
    }

    void InitSlider(Slider slider, string exposedParam, string prefsKey)
    {
        float savedValue = PlayerPrefs.GetFloat(prefsKey, 1f);
        slider.value = savedValue;
        SetVolume(exposedParam, savedValue);

        slider.onValueChanged.AddListener((value) =>
        {
            SetVolume(exposedParam, value);
            PlayerPrefs.SetFloat(prefsKey, value);
            PlayerPrefs.Save();
        });
    }

    void SetVolume(string exposedParam, float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat(exposedParam, dB);
    }
}
