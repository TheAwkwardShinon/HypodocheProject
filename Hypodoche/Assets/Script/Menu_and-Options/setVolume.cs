using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;


namespace Hypodoche {

    public class setVolume : MonoBehaviour
    {
        public AudioMixer audioMixer;

        [SerializeField] private Data_VolumeAndResolution _settings;
        [SerializeField] private GameObject _slider;
        public void Awake(){
            _slider.GetComponent<Slider>().value = _settings.volume;
            audioMixer.SetFloat("MusicVol", Mathf.Log10(_settings.volume)*20);
        }
        public void Start(){
 
        }

        public void setVol(float value)
        {
            audioMixer.SetFloat("MusicVol", Mathf.Log10(value)*20);
            _settings.volume = value;
        }
    }
}
