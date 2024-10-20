using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("AudioClip")] 
    [SerializeField] private AudioClip[] bgmClip;
    [SerializeField] private AudioClip[] sfxClip;


    [Header("AudioSource Pool")] 
    [SerializeField] private int audioSourcePoolsSize = 10;


    private AudioSource bgmAudioSource;
    private List<AudioSource> sfxAudioSourcePools = new List<AudioSource>();
    private Dictionary<string, AudioClip> sfxName = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> bgmName = new Dictionary<string, AudioClip>();


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
        CreateClipDictionary(sfxClip, sfxName, "SFX");
        CreateClipDictionary(bgmClip, bgmName, "BGM");
    }

    private void CreateClipDictionary(AudioClip[] clips, Dictionary<string, AudioClip> clipDictionary, string clipType)
    {
        foreach (var clip in clips)
        {
            if (!clipDictionary.ContainsKey(clip.name))
                clipDictionary.Add(clip.name, clip);
            
            else
                Debug.LogWarning($"중복된 {clipType} Clip: {clip.name}. 클립을 제거하거나 이름을 수정하세요.");
        }
    }


    private void CreateAudioSourcePools()
    {
        GameObject audioSourcePrefab = new GameObject("AudioSourcePrefab");
        AudioSource prefabAudioSource = audioSourcePrefab.AddComponent<AudioSource>();


        for (int i = 0; i < audioSourcePoolsSize; i++)
        {
            GameObject obj = Instantiate(audioSourcePrefab, this.transform);
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                sfxAudioSourcePools.Add(audioSource);
            }
        }

        Destroy(audioSourcePrefab);
    }

    private AudioSource GetSFXAudioSource()
    {
        foreach (var audioSource in sfxAudioSourcePools)
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
        AudioSource oldestAudioSource = sfxAudioSourcePools[0];
        float longestPlayTime = float.MinValue;

        foreach (var audioSource in sfxAudioSourcePools)
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


    public void PlaySfx(string name)
    {
        if (!sfxName.ContainsKey(name))
        {
            Debug.Log($"{name}과 동일한 효과음이 없습니다. 이름을 다시 확인해주세요.");
            return;
        }

        AudioSource source = GetSFXAudioSource();

        source.clip = sfxName[name];
        source.Play();
    }

    public void PlayBGM(string name)
    {
        if (!bgmName.ContainsKey(name))
        {
            Debug.Log($"{name}과 동일한 배경음이 없습니다. 이름을 다시 확인해주세요.");
            return;
        }


        if (bgmAudioSource.clip != bgmName[name])
        {
            bgmAudioSource.Stop();
            bgmAudioSource.clip = bgmName[name];
            bgmAudioSource.Play();
        }
    }
}