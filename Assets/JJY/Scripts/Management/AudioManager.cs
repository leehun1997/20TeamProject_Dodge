using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SfxType 
{
    Select = 0,
}

public enum BgmType 
{
    Start = 0,
    InGame,
    End
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    private AudioSource bgmAudioSource;
    
    [Header("AudioClip")]
    [Tooltip("각 Clip을 넣는 순서는 enum SfxType의 값에 맞춰서 넣어야 합니다.")]
    [SerializeField] private AudioClip[] bgmClip;
    [SerializeField] private AudioClip[] sfxClip;
   
    
    [Header("AudioSource Pool")]
    [SerializeField] private List<AudioSource> audioSourcePools;
    [SerializeField] private  GameObject audioSourcePrefab;   
    
    private int audioSourcePoolsSize = 10;

    private SfxType currentSfxType;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        bgmAudioSource = GetComponent<AudioSource>();
        CreateAudioSourcePools();
    }


    private void CreateAudioSourcePools()
    {
        audioSourcePools = new List<AudioSource>();

        for (int i = 0; i < audioSourcePoolsSize; i++)
        {
            GameObject obj = Instantiate(audioSourcePrefab);
            AudioSource audioSource = obj.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                obj.SetActive(false); 
                audioSourcePools.Add(audioSource); 
            }
        }
    }

    private AudioSource GetSFXAudioSource()
    {
        foreach (var audioSource in audioSourcePools)
        {
            if (!audioSource.isPlaying)  
            {
                audioSource.gameObject.SetActive(true);  
                return audioSource;
            }
        }
        return null;
    }
    
    public void PlaySfx(SfxType sfxType)
    {
        AudioSource source = GetSFXAudioSource();
      
        if (source != null)  
        {
            source.clip = sfxClip[(int)sfxType];
            source.Play();
        }
    }

    public void PlayBGM(BgmType bgmType)
    {
        // 기존 bgmAudioSource.clip과 같지 않으면
        if (bgmAudioSource.clip != bgmClip[(int)bgmType])  
        {
            bgmAudioSource.Stop();
            bgmAudioSource.clip = bgmClip[(int)bgmType];
            bgmAudioSource.Play();
        }
    }


}



