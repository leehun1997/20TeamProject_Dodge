using System.Collections.Generic;
using UnityEngine;

//TODO 볼륨 조절 기능

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
}