using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]//직렬화 직렬화 가능한 class,struct로 만들어진 객체instantiate는 상태를 저장, 복원 가능하다고 한다
//MonoBehavior를 상속하지 않음 = 컴포넌트 아님 = new키워드로 생성 불가

//스텟 정보를 PlayerStatHandler에서 값 초기화 됨
public class CharacterStat
{
    [Header ("playerStatHandler에서 초기화 될 것임")]
    [Header ("캐릭터 유형에 맞는 SO를 연결해야함")]
    public CharacterStatSO characterStatSO;
    public BulletSO bulletSO;
    public BulletSO specialBulletSO;
}