using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //UI
using UnityEngine.Audio;         //Audio

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicMasterSlider;
    [SerializeField] private Slider musicBGMSlider;
    [SerializeField] private Slider musicSFXSlider;


    private void Awake()
    {
        //마스터 슬라이더의 값이 변경될때 리스너를 통해서 함수에 값을 전달한다.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        //BGM 슬라이더의 값이 변경될때 리스너를 통해서 함수에 값을 전달한다.
        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        //SFX 슬라이더의 값이 변경될때 리스너를 통해서 함수에 값을 전달한다.
        musicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    //슬라이더 MinValue 0.001 사운드 불륨은 Log10 단위로 되어있기 때문에

    public void SetMasterVolume(float volume)                                       //마스터 불륨 슬라이더
    {
        audioMixer.SetFloat("Master", Mathf.Log(volume) * 20);
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log(volume) * 20);
    }
       

}
