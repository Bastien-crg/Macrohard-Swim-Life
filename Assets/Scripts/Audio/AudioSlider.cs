using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class AudioSlider : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;

    public void OnValueChange()
    {
        mixer.SetFloat("MainVolume", slider.value);
    }
}
