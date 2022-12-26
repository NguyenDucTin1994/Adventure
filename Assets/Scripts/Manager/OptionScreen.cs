using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class OptionScreen : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Text backgroundLabel, SFXLabel;
    public Slider backgroundSlider,SFXSlider;
    // Start is called before the first frame update
    void Start()
    {
        float tempVol = 0;
        audioMixer.GetFloat("BackgroundVolume", out tempVol);
        backgroundSlider.value = tempVol + 80;
        backgroundLabel.text = Mathf.RoundToInt(backgroundSlider.value).ToString();

        audioMixer.GetFloat("SFXVolume", out tempVol);
        SFXSlider.value = tempVol + 80;
        SFXLabel.text = Mathf.RoundToInt(SFXSlider.value).ToString();



    }

    // Update is called once per frame
    void Update()
    {
    }

   public void SetBackgroundVolume()
    {
        backgroundLabel.text = Mathf.RoundToInt( backgroundSlider.value).ToString();
        audioMixer.SetFloat("BackgroundVolume", backgroundSlider.value - 80);
        PlayerPrefs.SetFloat("BackgroundVolume", backgroundSlider.value - 80);
    }

    public void SetSFXVolume()
    {
        SFXLabel.text = Mathf.RoundToInt(SFXSlider.value).ToString();
        audioMixer.SetFloat("SFXVolume", SFXSlider.value - 80);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value - 80);

    }

    public void ResetHighScore()
    {
        HighScoreManager.ResetHighScore();
    }
}
