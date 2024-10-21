using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OnDeathFragment : MonoBehaviour
{
    [Header("유형에 맞는 파편 프리팹 연결")]
    [SerializeField] List<GameObject> fragmentPrefabs;

    private SpriteRenderer SpriteRenderer;

    private GameObject newObj;

    private float RandNum;
    private Vector2 makePosition;
    private int count = 0;

    public event Action OnDeathAnimationEnd;//템 드랍할때 씀 Dropper.cs
    
    private void Awake()
    {
        SpriteRenderer=GetComponent<SpriteRenderer>();
    }

    //Enemy_0_Death생성>Death종료>Add Animation Event에서 호출
    public void DeathAnimationEnd()
    {
        SpriteRenderer.enabled = false;
        InstancePrefabs();
        OnDeathAnimationEnd?.Invoke();
    }
    private void InstancePrefabs()//파편 동적생성, 자식화, 랜덤방향 돌리기
    {
        foreach (var obj in fragmentPrefabs)
        {
            RandNum = Random.Range(0f, 360f);
            newObj = Instantiate(obj, transform);
            obj.transform.localRotation = Quaternion.Euler(0, 0, RandNum);
        }
        
     }

    public void FragmentDisable()//자식 파편에서 호출
    {
        count += 1;
        if (count >= fragmentPrefabs.Count)//자식 파편에서 호출 생성한 파편만큼 제거되면 스프라이트on, gameObject비활성
        {
            SpriteRenderer.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
