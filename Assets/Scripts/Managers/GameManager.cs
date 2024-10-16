using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPool;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //GameManager를 다른 곳에서 쉽게 접근가능
    [SerializeField ]private string playerTag;

    public Transform Player { get; private set; } //읽기는 가능하지만 다른 곳에서 초기화 불가능

    public ObjectPool Pool {  get; private set; } //읽기는 가능하지만 다른 곳에서 초기화 불가능

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //씬 전환 후에도  GameManager 유지하기 위해
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Player초기화
        Player = GameObject.FindGameObjectWithTag(playerTag).transform; //PlayerTag에 맞는 tag를 가지고 있는 오브젝트의 transform정보를 Palyer에 넣어준다/

        Pool = FindObjectOfType<ObjectPool>(); //씬 안에 ObjectPool 붙어있는 오브젝트를 찾고Pool변수에 참조로 넣어 게임 매니저에서 그풀을 사용
    }
}
