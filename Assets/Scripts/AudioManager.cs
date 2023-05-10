using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = .2f;
    [Range(.1f, 3f)]
    public float pitch = 1;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}


public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager instance;

    #endregion

    public AudioMixer masterMixer;

    [SerializeField] private AudioMixerGroup SFXGroup;
    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private Sound[] sounds;
    [SerializeField] private Sound[] themes;

    private void Awake()
    {
        instance = this;

        foreach (Sound sound in sounds)
        {
            CreateSound(sound, SFXGroup);
        }

        foreach (Sound theme in themes)
        {
            CreateSound(theme, musicGroup);
        }
    }

    private void Start()
    {
        if (themes.Length > 0)
            themes[0].source.Play();
    }

    private Sound FindSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found!");
            return null;
        }

        return s;
    }

    public void Play(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
            return;

        s.source.Play();
    }

    public void PlayOnce(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
            return;

        if (s.source.isPlaying)
            return;

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
            return;

        s.source.Stop();
    }

    private void CreateSound(Sound sound, AudioMixerGroup mixerGroup)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.outputAudioMixerGroup = mixerGroup;

        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;
    }
}
