 
using UnityEngine;
using UnityEngine.UI;

public enum SliderType
{
    BGM,
    SFX
}

public class VolumeSlider : MonoBehaviour
{
    [SerializeField]private SliderType type;
    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        if(type == null)
            Debug.LogError("Volume Slider Type이 설정 돼있지 않습니다.");
        
        switch (type)
        {
            case SliderType.BGM:
                AudioManager.Instance.SetBGMVolume(value);
                break;
            case SliderType.SFX:
                AudioManager.Instance.SetSFXVolume(value);
                break;
        }
    }

}
