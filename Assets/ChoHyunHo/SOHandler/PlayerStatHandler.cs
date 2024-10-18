using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStatHandler : CharacterStatHandler
{
    [SerializeField] public PlayerStatSO basePlayerStatSO;
    [SerializeField] public PlayerBulletSO basePlayerBulletSO;

    public string desc { get; private set; }
    public int id { get; private set; }
    public double gage { get; private set; }


    protected override void InitialSetup()
    {
        PlayerStatSO playerStatSO = null;
        PlayerBulletSO playerBulletSO = null;


        if (basePlayerStatSO != null && basePlayerBulletSO != null)
        {
            playerStatSO = Instantiate(basePlayerStatSO);
            playerBulletSO = Instantiate(basePlayerBulletSO);
        }

        
        currentStat = new CharacterStat
        {
            characterStatSO = playerStatSO,
            bulletSO = playerBulletSO
        };

        
        
        desc = basePlayerStatSO.str;
        id = basePlayerStatSO.id;
        gage = basePlayerStatSO.specialGage;
        
        //기본 스텟
        speed = basePlayerStatSO.MoveSpeed;
        maxHp = basePlayerStatSO.MaxHP;
        damage = basePlayerBulletSO.damage;
    }
}