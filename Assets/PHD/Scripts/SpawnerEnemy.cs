using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] string bombEnemy;
    [SerializeField] string rangeEnemy;

    private float BombInstanceTime = 8f;
    private float RangeInstanceTime = 3f;
    private float checkBombInstanceTime = 0f;
    private float checkRangeInstanceTime = 0f;
    private float randomPosX;
    private float randomPosY;

    private BombEnemyController _bombEnemyController;
    private RangeEnemyController _rangeEnemyController;
    private ObjectPool objectPool;

    private void Awake()
    {
        objectPool = GameObject.FindObjectOfType<ObjectPool>();
    }
    private void Update()
    {
        checkRangeInstanceTime += Time.deltaTime;
        checkBombInstanceTime += Time.deltaTime;
        
        if (checkRangeInstanceTime > RangeInstanceTime)
        {
            randomPos();
            CreateRangeEnemy();
            checkRangeInstanceTime = 0;
            RangeInstanceTime = Random.Range(2f, 3f);
        }

        if (checkBombInstanceTime > BombInstanceTime)
        {
            randomPos();
            CreateBombEnemy();
            checkBombInstanceTime = 0;
            BombInstanceTime = Random.Range(8f, 16f);
        }

    }

    private void CreateRangeEnemy()
    {
        GameObject RangeEnemyClone = objectPool.SpawnFromPool(rangeEnemy);
        if (RangeEnemyClone != null)
        {
            RangeEnemyClone.transform.position = new Vector3(randomPosX, randomPosY);
            _rangeEnemyController = RangeEnemyClone.GetComponent<RangeEnemyController>();
        }
    }

    private void CreateBombEnemy() 
    {
        GameObject BombEnemyClone = objectPool.SpawnFromPool(bombEnemy);
        if (BombEnemyClone != null) 
        {
            BombEnemyClone.transform.position = new Vector3(randomPosX, randomPosY);
            _bombEnemyController = BombEnemyClone.GetComponent<BombEnemyController>();
            _bombEnemyController.Init();
        }
        
    }

    private void randomPos() 
    {
        float sup = 12f;
        randomPosX = Random.Range(-12f,12f);
        randomPosY = sup - MathF.Abs(randomPosX);
        randomPosY = Random.Range(-1, 1) == -1 ? -randomPosY : randomPosY;

    }


}

