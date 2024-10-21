using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_0_Death : MonoBehaviour
{
    [Header("캐릭터 유형에 맞는 파편을 자식화 한 후 등록")]
    [SerializeField] List<GameObject> fragments;

    private SpriteRenderer SpriteRenderer;

    private float RandNum;
    private Vector2 makePosition;

    private void Awake()
    {
        SpriteRenderer=GetComponent<SpriteRenderer>();
    }

    //Enemy_0_Death애니메이터>Death애니메이션>Add Animation Event에서 호출됨
    public void DeathAnimationEnd()
    {
        //애니메이션 실행 > 끝나면 자기 sprite비활성화 자식들 활성화
        //오브젝트풀 들어갈때 자식끄기 자기 sprite켜기
        //자식 로컬로테이션 바꾸기 오브젝트 풀이 필요하다

        SpriteRenderer.enabled = false;
        foreach (var obj in fragments)
        {
            RandNum = Random.Range(0f, 360f);
            obj.SetActive(true);
            obj.transform.localRotation = Quaternion.Euler(0, 0, RandNum);

            //별도의 스크립트로 처리 여기서는 작동하지않음
            //objRigid2D = obj.GetComponent<Rigidbody2D>();
            //objRigid2D.AddForce(transform.TransformDirection(Vector2.right) / 2, ForceMode2D.Impulse);
        }
        
    }

    //꺼질때(오브젝트풀에 들어갈때) SpriteRenderer.enabled = 

}
