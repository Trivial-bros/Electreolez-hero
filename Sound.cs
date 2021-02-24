using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string AudioName;

    public AudioClip AudioClip;

    [Range(0f, 1)]
    public float Volume;
    [Range(.1f, 3)]
    public float Pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}