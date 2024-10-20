using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SfxType
{
    Select = 0,
    EnemyDeath  
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
    [Tooltip("각 Clip은 SfxType의 순서에 맞게 넣어야 합니다. 필요한 SfxType이 없으면 enum에 값을 추가하세요.")]
    [SerializeField]
    private AudioClip[] bgmClip;

    [SerializeField] private AudioClip[] sfxClip;


    [Header("AudioSource Pool")] 
    [SerializeField] private GameObject audioSourcePrefab;
    private List<AudioSource> audioSourcePools;

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
            GameObject obj = Instantiate(audioSourcePrefab, this.transform);
            AudioSource audioSource = obj.GetComponent<AudioSource>();

            if (audioSource != null)
            {
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
                return audioSource;
            }
        }

        return RecycleAudioSource();
    }


    private AudioSource RecycleAudioSource()
    {
        AudioSource oldestAudioSource = audioSourcePools[0];
        float longestPlayTime = float.MinValue;

        foreach (var audioSource in audioSourcePools)
        {
            if (audioSource.time > longestPlayTime)
            {
                oldestAudioSource = audioSource;
                longestPlayTime = audioSource.time;
            }
        }

        oldestAudioSource.Stop();
        return oldestAudioSource;
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