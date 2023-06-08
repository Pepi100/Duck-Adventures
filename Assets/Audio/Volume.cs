using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private TextMeshProUGUI ValueText;
    [SerializeField]
    private AudioMixMode MixMode;

    private void Start()
    {
        Mixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1)*20));

        float volume = PlayerPrefs.GetFloat("Volume");

        Slider slider = GetComponent<Slider>();

        slider.value = volume; 

        Debug.Log("Volume:" + volume);
    }


    public void OnChangeSlider(float Value)
    {

        ValueText.SetText($"{Value.ToString("N2")}");
    
        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = Value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume", (-80 + Value*80));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value)*20);
                break;
        }

        float a = Mathf.Log10(Value) * 20;

        PlayerPrefs.SetFloat("Volume", Value);
        PlayerPrefs.Save();
    }

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
}
