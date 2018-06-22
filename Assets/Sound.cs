using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]

public class Sound  {
    public string name;
    [HideInInspector]
    public AudioSource a;
    
    public float volume;
    [Range(0f,1.5f)]public float pitch;
    
    public AudioClip audioclip;
    



}
