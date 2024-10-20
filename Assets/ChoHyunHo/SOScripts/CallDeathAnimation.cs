using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CallDeathAnimation : MonoBehaviour
{
    SpawnerEnemy Spawner;


    private void Awake()
    {
        Spawner = GameObject.FindObjectOfType<SpawnerEnemy>();
    }

    private void OnDisable()//헬스 시스템OnDeath에 구독된 DestroyOnDeath.OnDeath()에서 꺼준다
    {
        //오브젝트 풀에서 생성된 객체들은 이름에(Clone)이 붙는다 이걸 제거한 깔끔한 이름을 줘야한다
        //생성시 위치, 방향을 동일하게 하기위해 tranform도 매개변수로 전달한다
        Spawner.CreateDeathAnimation(gameObject.name.Remove(name.Length - 7), gameObject.transform);
    }
}
