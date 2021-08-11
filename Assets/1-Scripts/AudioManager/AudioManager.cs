using UnityEngine;
using System.Collections.Generic;
using System;

public class AudioManager : MonoBehaviour
{

    public List<Sound> sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach (var item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.volume = item.volume;
            item.source.pitch = item.pitch;
            item.source.loop = item.loop;
        }
    }

    private void Start()
    {
        //Play("ThemeSound");
    }

    public void Play(string SoundName)
    {
        Sound sound = sounds.Find(s => s.name.Equals(SoundName));
        if (sound == null)
        {
            throw new Exception("Sound" + SoundName + " Not Found");
        }
        sound.source.Play();
    }

    public void Stop(string SoundName)
    {
        Sound sound = sounds.Find(s => s.name.Equals(SoundName));
        if (sound == null)
        {
            throw new Exception("Sound" + SoundName + " Not Found");
        }
        sound.source.Stop();
    }
}
