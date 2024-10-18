using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

//SOㅇ[ㅔ사ㅓ 변경 되는 데이터 , 안 되는 데이터 구분

public class EnemyStatHandler : CharacterStatHandler
{
    [SerializeField] public EnemyStatSO baseEnemyStatSO;
    [SerializeField] public EnemyBulletSO baseEnemyBulletSO;


    protected override void InitialSetup()
    {
        EnemyStatSO enemyStatSo = null;
        EnemyBulletSO enemyBulletSo = null;


        if (baseEnemyStatSO != null && baseEnemyBulletSO != null)
        {
            enemyStatSo = Instantiate(baseEnemyStatSO);
            enemyBulletSo = Instantiate(baseEnemyBulletSO);
        }

        currentStat = new CharacterStat
        {
            characterStatSO = enemyStatSo,
            bulletSO = enemyBulletSo
        };

        speed = baseEnemyStatSO.MoveSpeed;
        maxHp = baseEnemyStatSO.MaxHP;
        damage = baseEnemyBulletSO.damage;
    }
}