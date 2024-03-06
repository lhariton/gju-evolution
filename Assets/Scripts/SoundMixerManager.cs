using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("Master Volume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFxVolume(float level) {
        audioMixer.SetFloat("SoundFX Volume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level) {
        audioMixer.SetFloat("Music Volume", Mathf.Log10(level) * 20f);
    }
}

