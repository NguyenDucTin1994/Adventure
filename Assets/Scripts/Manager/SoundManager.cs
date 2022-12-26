using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer theMixer;
    public AudioClip[] soundClips;
    private AudioSource audioSource;
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance!=this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("BackgroundVolume"))
            theMixer.SetFloat("BackgroundVolume", PlayerPrefs.GetFloat("BackgroundVolume"));

        if (PlayerPrefs.HasKey("SFXVolume"))
            theMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(int clipindex)
    {
        instance.audioSource.clip = instance.soundClips[clipindex];
        instance.audioSource.Play();
    }
    public static void StopSound()
    {
        instance.audioSource.Stop();
    }
}
