using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

//TODO 1 볼륨 조절 기능 추가
//TODO 2 중앙집중식 오디오 관리 방식을 효과음을 사용하는 오브젝트에서 재생하는 방식으로 변경.


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [Header("AudioDatSO")] [SerializeField]
    private AudioDataSO[] audioDataSO;

    [SerializeField] private AudioDataSO defaultAudioDataSO;

    [Header("AudioSource Pool")] [SerializeField]
    private int audioSourcePoolsSize = 10;

    private AudioSource bgmAudioSource;
    private List<AudioSource> sfxAudioSourcePools = new List<AudioSource>();
    private Dictionary<string, AudioClip> sfxName = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> bgmName = new Dictionary<string, AudioClip>();

    private AudioClip[] sfxClip;
    private AudioClip[] bgmClip;

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


    private void Start()
    {
        InitAudioSource();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }



    public void SetBGMVolume(float value)
    {
        bgmAudioSource.volume = value;
    }

    public void SetSFXVolume(float value)
    {
        foreach (var source in sfxAudioSourcePools)
        {
            source.volume = value;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitAudioSource();
    }

    
    private void InitAudioSource()
    {
        SetAudioData();
        CreateClipDictionary(sfxClip, sfxName, "SFX");
        CreateClipDictionary(bgmClip, bgmName, "BGM");
    }

    private void SetAudioData()
    {
        bool isAudioDataFound = false;

        foreach (var audioData in audioDataSO)
        {
            if (audioData.targetSceneName == SceneManager.GetActiveScene().name)
            {
                bgmClip = audioData.bgm;
                sfxClip = audioData.sfx;
                isAudioDataFound = true;
                break;
            }
        }

        if (!isAudioDataFound)
        {
            if (defaultAudioDataSO == null)
            {
                Debug.LogError("씬에 해당하는 오디오 데이터 혹은 기본 데이터를 넣어주세요.");
                return;
            }
            
            Debug.LogWarning("씬에 해당하는 오디오 데이터가 없어 기본값으로 설정합니다.");
            bgmClip = defaultAudioDataSO.bgm;
            sfxClip = defaultAudioDataSO.sfx;
        }
    }


    private void CreateClipDictionary(AudioClip[] clips, Dictionary<string, AudioClip> clipDictionary, string clipType)
    {
        if (clipDictionary != null)
            clipDictionary.Clear();

        foreach (var clip in clips)
        {
            if (!clipDictionary.ContainsKey(clip.name))
                clipDictionary.Add(clip.name, clip);

            else
                Debug.LogError($"중복된 {clipType} Clip: {clip.name}. 클립을 제거하거나 이름을 수정하세요.");
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


    /// <summary>
    /// SFX CLIP에 있는 이름을 키값으로 사용해 재생
    /// EX) PlaySfx("CLIP NAME")
    /// </summary>
    public void PlaySfx(string sfxNameToPlay)
    {
        if (!sfxName.ContainsKey(sfxNameToPlay))
        {
            Debug.Log($"{sfxNameToPlay}과 동일한 효과음이 없습니다. 이름을 다시 확인해주세요.");
            return;
        }

        AudioSource source = GetSFXAudioSource();

        source.clip = sfxName[sfxNameToPlay];
        source.Play();
    }


    /// <summary>
    /// BGM CLIP에 있는 이름을 키값으로 사용해 재생
    /// EX) PlaySfx("CLIP NAME")
    /// </summary>
    public void PlayBGM(string bgmNameToPlay)
    {
        if (!bgmName.ContainsKey(bgmNameToPlay))
        {
            Debug.Log($"{bgmNameToPlay}과 동일한 배경음이 없습니다. 이름을 다시 확인해주세요.");
            return;
        }

        bgmAudioSource.Stop();
        bgmAudioSource.clip = bgmName[bgmNameToPlay];
        bgmAudioSource.Play();
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
