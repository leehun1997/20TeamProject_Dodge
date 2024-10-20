using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathFragment : MonoBehaviour
{
    [Header("캐릭터 유형에 맞는 파편을 자식화 한 후 등록")]
    [SerializeField] List<GameObject> fragmentPrefabs;

    private SpriteRenderer SpriteRenderer;

    private GameObject newObj;

    private float RandNum;
    private Vector2 makePosition;
    private int count = 0;

    

    private void Awake()
    {
        SpriteRenderer=GetComponent<SpriteRenderer>();
    }

    //Enemy_0_Death애니메이터>Death애니메이션>Add Animation Event에서 호출됨
    public void DeathAnimationEnd()
    {
        SpriteRenderer.enabled = false;
        InstancePrefabs();
    }
    private void InstancePrefabs()//인스펙터에서 등록된 파편프리팹들 객체화
    {
        foreach (var obj in fragmentPrefabs)
        {
            RandNum = Random.Range(0f, 360f);
            newObj = Instantiate(obj, transform);
            obj.transform.localRotation = Quaternion.Euler(0, 0, RandNum);
        }
    }

    public void FragmentDisable()//자식인 파편들이 비활성화(제거)되면 호출
    {
        count += 1;
        if (count >= fragmentPrefabs.Count)//모든 파편이 비활성화(제거)되면 껏던 렌더러on, gameObject비활성화
        {
            SpriteRenderer.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
