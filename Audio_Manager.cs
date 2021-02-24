using UnityEngine.Audio;
using UnityEngine;
using System;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] sounds;
    
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.AudioClip;

            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Title Screen Theme");
    }

    public void Play(string name)
    {
       Sound s =  Array.Find(sounds, Sound => Sound.AudioName == name);
        if(s == null)
        {
            Debug.LogWarning("The sound " + name + " wasn't found! Consider Checking spelling?");
            return;                                          
        }
        s.source.Play();
    }
}
