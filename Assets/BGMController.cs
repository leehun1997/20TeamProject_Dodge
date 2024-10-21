using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    void Start()
    {
        PlayRandomBGM();
    }

    private void PlayRandomBGM()
    {
        List<string> bgmKeyList = AudioManager.Instance.GetDictionaryKey(ClipDictionaryType.BGM);

        if (bgmKeyList.Count == 0 )
            return;

        int rand = Random.Range(0, bgmKeyList.Count);
        AudioManager.Instance.PlayBGM(bgmKeyList[rand]);

        StartCoroutine(nameof(WaitForBGMToEnd));
    }


    private IEnumerator WaitForBGMToEnd()
    {
        while (AudioManager.Instance.bgmAudioSource.isPlaying)
        {
            yield return null;
        }

        PlayRandomBGM();
    }
}