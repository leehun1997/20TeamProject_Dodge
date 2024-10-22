using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OnDeathFragment : MonoBehaviour
{
    [Header("유형에 맞는 파편 프리팹 연결")]
    [SerializeField] List<GameObject> fragmentPrefabs;
    private List<GameObject> childrenFragments = new List<GameObject>();

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

    //SetActive(false)일때 포문이 도는걸 보면 비활성화여도 처리가 되는듯
    //오브젝트풀에서 생성후 바로 SetActive(false)된다
    private void OnDisable() //InstancePrefabs()에서 만들고 childrenFragments에 Add
    {
        
        if (childrenFragments.Count == 0)
        {
            InstancePrefabs();//파편생성 한적없음 = 파편생성 최초 1회만 실행
        }

    }

    private void OnEnable()//오브젝트풀에서 최초생성하고 끄기전에 수행을 완료할수없다?
    {
        //오브젝트 풀에서 가져와 활성화 됬을때 자식(파편) 전부 활성화   

        //파편도 SetActive 왔다갔다 할 것임

        //내 자식 오브젝트가 있다 = 자식들도 켜준다
        if (childrenFragments.Count != 0)
        {
            for (int i = 0; i < fragmentPrefabs.Count; i++)
            {
                Debug.Log(i);
                this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    //Enemy_0_Death생성>Death종료>Add Animation Event에서 호출
    public void DeathAnimationEnd()
    {
        SpriteRenderer.enabled = false;
        
        OnDeathAnimationEnd?.Invoke();
    }
    private void InstancePrefabs()//파편 동적생성, 자식화, 랜덤방향 돌리기
    {
        Debug.Log(this.gameObject.name + "InstancePrefabs");

        foreach (var obj in fragmentPrefabs)
        {
            RandNum = Random.Range(0f, 360f);
            newObj = Instantiate(obj, transform);
            newObj.transform.localRotation = Quaternion.Euler(0, 0, RandNum);
            childrenFragments.Add(newObj);
        }
        
    }

    public void FragmentDisable()//자식 파편에서 호출
    {
        count += 1;
        if (count >= fragmentPrefabs.Count)//자식 파편에서 호출 생성한 파편만큼 제거되면 스프라이트on, gameObject비활성
        {
            SpriteRenderer.enabled = true;
            gameObject.SetActive(false);
            count = 0;
        }
    }
}
