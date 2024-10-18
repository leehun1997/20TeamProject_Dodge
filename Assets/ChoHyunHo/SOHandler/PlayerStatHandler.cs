using System.Threading;
using UnityEngine;

public class PlayerStatHandler : CharacterStatHandler
{
    [SerializeField] public PlayerStatSO PlayerStatSo;
    [SerializeField] public BulletSO PlayerBulletSo;

    protected override void InitialSetup()
    {

        base.InitialSetup();
        currentStat = new CharacterStat
        {
            characterStatSO = PlayerStatSo,
            bulletSO = PlayerBulletSo
        };
    }
}