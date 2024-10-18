using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "StatSO/PlayerStatSO", order = 1)]
public class PlayerStatSO : CharacterStatSO
{
    [Header("플레이어 고유 스텟")]
    public int specialGage;
    public string str = "아직 플레이어 고유의 스텟이 없음";
    public int id = 0; 
}
