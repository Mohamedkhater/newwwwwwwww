using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.a = gameObject.AddComponent<AudioSource>();
            s.a.clip = s.audioclip;
            s.a.volume = s.volume;
            s.a.pitch = s.pitch;
            

        }
        
    }
    private void Start()
    {
        Play("Tribal Rumble");
    }
    public void Play(string name)
    {
       Sound s= Array.Find(sounds, sound => sound.name == name);
        s.a.Play();
        
        
         
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds , sound => sound.name==name);
        s.a.Stop();

    }


}
 
