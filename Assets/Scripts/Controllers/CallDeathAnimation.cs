using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CallDeathAnimation : MonoBehaviour
{
    SpawnerEnemy Spawner;
    private HealthSystem healthSystem;

    private void Awake()
    {
        Spawner = GameObject.FindObjectOfType<SpawnerEnemy>();
        healthSystem = GetComponent<HealthSystem>();
    }
    
    private void Start()
    {
        healthSystem.OnDeath += OnDeathAnim;
    }
    
    private void OnDeathAnim()//DestroyOnDeath.OnDeath()
    {
        //스포너에 생성된 객체는 이름에(Clone)가 붙음 이걸제거하고 키값으로
        //사망 애니메이션용 프리팹이 똑같은 위치에 똑같은 방향으로 생성되어야함
        Spawner.CreateDeathAnimation(gameObject.name.Remove(name.Length - 7), gameObject.transform);
    }

}
