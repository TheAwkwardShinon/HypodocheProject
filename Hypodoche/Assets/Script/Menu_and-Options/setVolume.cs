using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



namespace Hypodoche {

    public class setVolume : MonoBehaviour
    {
        public AudioMixer audioMixer;


        public void setVol(float value)
        {
            audioMixer.SetFloat("MusicVol", Mathf.Log10(value)*20);
        }
    }
}
