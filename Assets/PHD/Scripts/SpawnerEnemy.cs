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

    private float instanceTime = 3f;
    private float checkBombInstanceTime = 0f;
    private float checkRangeInstanceTime = 0f;

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
        
        if (checkRangeInstanceTime > instanceTime)
        {
            randomPos();
            CreateRangeEnemy();
            checkRangeInstanceTime = 0;
        }

        if (checkBombInstanceTime > instanceTime * 2.5f)
        {
            randomPos();
            CreateBombEnemy();
            checkBombInstanceTime = 0;
        }

    }

    private void CreateRangeEnemy()
    {
        GameObject RangeEnemyClone = objectPool.SpawnFromPool(rangeEnemy);
        if (RangeEnemyClone != null)
        {
            RangeEnemyClone.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
            _rangeEnemyController = RangeEnemyClone.GetComponent<RangeEnemyController>();
        }
    }

    private void CreateBombEnemy() 
    {
        GameObject BombEnemyClone = objectPool.SpawnFromPool(bombEnemy);
        if (BombEnemyClone != null) 
        {
            BombEnemyClone.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
            _bombEnemyController = BombEnemyClone.GetComponent<BombEnemyController>();
            _bombEnemyController.Init();
        }
    }

    public void CreateDeathAnimation(string name, Transform makeTransform)//사망 애니메이션용 객체를 생성해야할 객체가 호출
    {
        Debug.Log("함수시작");
        GameObject Enemy_0_Death = objectPool.SpawnFromPool(name + "_Death");
        Debug.Log("오브젝트 이름: " + Enemy_0_Death.name);
        Enemy_0_Death.transform.position = makeTransform.position;
        Enemy_0_Death.transform.rotation = makeTransform.rotation;
    }

    private void randomPos() 
    {
        float sup = 9f;
        float x = Random.Range(-9f,9f);
        float y = sup - MathF.Abs(x);
        y = Random.Range(-1, 1) == -1 ? -y : y;

    }


}

