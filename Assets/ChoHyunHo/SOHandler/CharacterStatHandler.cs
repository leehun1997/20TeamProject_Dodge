using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 스텟을 최초에 초기화만 해줄 클래스
public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat characterStat;//인스펙터에서 연결 한 후 해당 캐릭터에 맞는 SO를 연결해야함
    private CharacterStatSO instanceCharacterStatSO;//인스펙터에서 연결할 대상이 아님
    private BulletSO instanceBulletSO;//인스펙터에서 연결할 대상이 아님
    //최상위 부모 SO인 이유 상속받는 SO가 다 호환된다 실제로 연결할 SO는 characterStat의 SO들 (캐릭터 유형에 맞는 SO를 넣어야한다)

    //아무나 조회가능 세팅은 이 클래스만
    public CharacterStat currentStat { get; private set; }

    private void Awake()
    {
        InitialSetup();//초기설정 이라는 뜻
    }
    
    private void InitialSetup()
    {
        instanceCharacterStatSO = null;
        instanceBulletSO = null;
        //currentStat은 직렬화되어 상태가 유지,보존 된다 아무것도 없을 때(최초)만 초기화한다
        if (characterStat.characterStatSO == null)
        {
            Debug.Log("characterStatSO 연결하지않음");
        }
        if (characterStat.bulletSO == null)
        {
            Debug.Log("bulletSO 연결하지않음");
        }
        
        if (characterStat.bulletSO != null)
        {
            instanceBulletSO = Instantiate(characterStat.bulletSO);
            //밑의 CharacterStat 프로퍼티 초기화에 바로 사용 불가 bulletSO = Instantiate(characterStat.bulletSO)안됨
        }

        if (characterStat.characterStatSO != null)
        {
            instanceCharacterStatSO = Instantiate(characterStat.characterStatSO);
        }

        currentStat = new CharacterStat
        {
            characterStatSO = instanceCharacterStatSO,
            bulletSO = instanceBulletSO
        };
        //ShowDebug();
    }

    private void ShowDebug()
    {
        Debug.Log(gameObject.name);
        Debug.Log("초기설정 스탯SO : " + currentStat.characterStatSO);
        Debug.Log("초기설정 최대HP : " + currentStat.characterStatSO.MaxHP);
        Debug.Log("초기설정 이동속도 : " + currentStat.characterStatSO.MoveSpeed);
        Debug.Log("초기설정 총알SO : " + currentStat.bulletSO);
        Debug.Log("총알SO 타겟: " + currentStat.bulletSO.targetLayer);
        Debug.Log("총알SO 공격력 : " + currentStat.bulletSO.damage);
        Debug.Log("총알SO 크기 : " + currentStat.bulletSO.size);
        Debug.Log("총알SO 속도 : " + currentStat.bulletSO.speed);
        Debug.Log("총알SO 딜레이 : " + currentStat.bulletSO.delay);
        Debug.Log("총알SO 프리팹: " + currentStat.bulletSO.bulletPrefab);
    }

}


