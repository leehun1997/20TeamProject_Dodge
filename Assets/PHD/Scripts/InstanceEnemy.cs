using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstanceEnemy : MonoBehaviour
{
    public GameObject instanceRangeEnemy;
    public GameObject instanceBombEnemy;
    string bombPrefabPath = "TestPrefab/BombEnemy";
    string rangePrefabPath = "TestPrefab/RangeEnemy"; // 인스턴스는 리소스 하위 파일만 가능하다
    private float instanceTime = 3f;
    private float checkInstanceTime = 0f;
    Vector2 randomPosition;


    private void Start()
    {
        randomPosition = new Vector2();
    }

    private void Update()
    {
        checkInstanceTime += Time.deltaTime;
        if (checkInstanceTime > instanceTime)
        {
            RandomPosUpply();
            instanceRangeEnemy = SpawnPrefab(rangePrefabPath, randomPosition);
            instanceBombEnemy = SpawnPrefab(bombPrefabPath, randomPosition);
            checkInstanceTime = 0f;
            // 생성시 플레이어 바라보는 방향값 작성
        }
    }

    private void RandomPosUpply()
    {
        randomPosition.x=Random.Range(-10f, 10f);
        randomPosition.y = Random.Range(-5f, 5f);
    }

    private GameObject SpawnPrefab(string prefabPath , Vector3 spawnPos /*, Quaternion direction*/)
    {
        GameObject PreBomb =  Resources.Load(prefabPath) as GameObject;
        //불러오기 , 인스펙터상에 수정 가능 정도
        if (PreBomb != null)
        {
            return Instantiate(PreBomb , spawnPos , Quaternion.identity/* direction*/ );  
            // 씬에 생성
        }
        else 
        {
            Debug.Log(prefabPath +"null");
            return null;
        }
    }

}

