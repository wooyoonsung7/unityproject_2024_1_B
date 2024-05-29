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
        //������ �����̴��� ���� ����ɶ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        //BGM �����̴��� ���� ����ɶ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        //SFX �����̴��� ���� ����ɶ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    //�����̴� MinValue 0.001 ���� �ҷ��� Log10 ������ �Ǿ��ֱ� ������

    public void SetMasterVolume(float volume)                                       //������ �ҷ� �����̴�
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
