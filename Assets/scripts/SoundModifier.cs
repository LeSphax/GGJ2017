using System.Collections.Generic;
using UnityEngine;

public class SoundModifier : MonoBehaviour
{

    public static GameObject head;

    public static List<AudioSource> audioSources;
    public AudioSource playerAudio;
    public SinusMovement sinusMovement;

    public float volumeMin;
    public float baseVolume;
    public float volumeMax;

    public float pitchMin;
    public float basePitch;
    public float pitchMax;

    private void Awake()
    {
        audioSources = new List<AudioSource>();
        audioSources.Add(playerAudio);
        head = gameObject;
    }

    void Update()
    {
        float volume;
        if (sinusMovement.currentAmplitude > sinusMovement.baseAmplitude)
            volume = (sinusMovement.currentAmplitude - sinusMovement.baseAmplitude) / (sinusMovement.amplitudeMax - sinusMovement.baseAmplitude) * (volumeMax - baseVolume) + baseVolume;
        else
            volume = (sinusMovement.currentAmplitude - sinusMovement.amplitudeMin) / (sinusMovement.baseAmplitude - sinusMovement.amplitudeMin) * (baseVolume - volumeMin) + volumeMin;

        float pitch;
        if (sinusMovement.currentFrequency > sinusMovement.baseFrequency)
            pitch = (sinusMovement.currentFrequency - sinusMovement.baseFrequency) / (sinusMovement.frequencyMax - sinusMovement.baseFrequency) * (pitchMax - basePitch) + basePitch;
        else
            pitch = (sinusMovement.currentFrequency - sinusMovement.frequencyMin) / (sinusMovement.baseFrequency - sinusMovement.frequencyMin) * (basePitch - pitchMin) + pitchMin;

        foreach(AudioSource source in audioSources)
        {
            source.volume = volume;
            source.pitch = pitch;
        }
        //audioSource.pitch = sinusMovement.frequency;
    }
}
