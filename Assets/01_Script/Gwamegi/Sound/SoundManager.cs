using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;


    public void Start()
    {
        float ming;
        _audioMixer.GetFloat("Master",out ming);
        _slider.value = ming;
    }

    private void Update()
    {
        //_audioSource.volume = _slider.value;

        _audioMixer.SetFloat("Master", _slider.value);
    }

}
