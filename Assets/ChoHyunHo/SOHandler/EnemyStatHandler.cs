using UnityEngine;
using UnityEngine.Serialization;

public class EnemyStatHandler : CharacterStatHandler
{
     [SerializeField] public EnemyStatSO enemyStatSo;
   [SerializeField] public BulletSO enemyBulletSo;

    protected override void InitialSetup()
    {

        base.InitialSetup();
        currentStat = new CharacterStat
        {
            characterStatSO = enemyStatSo,
            bulletSO = enemyBulletSo
        };
    }
}