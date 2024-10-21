 using UnityEngine;

 [CreateAssetMenu(fileName = "AudioData", menuName = "AudioDataSO/AudioData", order = 4)]
public class AudioDataSO : ScriptableObject
{
    public string targetSceneName;
    public AudioClip [] bgm;
    public AudioClip [] sfx;
}
