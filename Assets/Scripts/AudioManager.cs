using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup audioMixer;

    public Sound[] sounds;

    public static AudioManager instance;

    bool SceneLoaded = false;

    void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.outputAudioMixerGroup = audioMixer;
        }
    }

    private void Start ()
    {
        Play("MenuBG");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    public void StopPlaying (string sound)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound + "not found!");
            return;
        }
        else
        {
            s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
            s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));

            s.source.Stop();
        }
    }
    
    void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StopPlaying("MenuBG");
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (SceneLoaded != true)
                Play("GameBG");
            SceneLoaded = true;
        }

        if (GameManager.gameWin == true)
        {
            Play("GameWin");
        }
        else
        {
            Play("GameLose");
        }
    }
}