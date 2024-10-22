using System;
using UnityEngine;
using UnityEngine.UI;

public class GageSystem : MonoBehaviour
{
    // [Header("Health System Settings")]

    private CharacterStatHandler statHandler;

    private float maxGage => statHandler.currentStat.characterStatSO.MaxGage;

    public double currentGage;
    public double cHargeGage = 0;

    public Slider gageSlider; //슬라이더를 인스펙터에서 가져옴
    [SerializeField] private bool isPlayer; // 플레이어 여부 확인

    private void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
    }


    private void Start()
    {
        currentGage = maxGage;
    }



    public void ChangeGage()
    {
        gageSlider.value = (float)((currentGage-cHargeGage)/maxGage);
    }




}