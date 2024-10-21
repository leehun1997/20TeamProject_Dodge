using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStatHandler : CharacterStatHandler
{
    [SerializeField] public PlayerStatSO basePlayerStatSO;
    [SerializeField] public PlayerBulletSO basePlayerBulletSO;
    [SerializeField] public PlayerBulletSO basePlayerSpecialBulletSO;

    public string desc { get; private set; }
    public int id { get; private set; }
    public double gage { get; private set; }


    protected override void InitialSetup()
    {
        PlayerStatSO playerStatSO = null;
        PlayerBulletSO playerBulletSO = null;
        PlayerBulletSO playerSpecialBulletSO = null;


        if (basePlayerStatSO != null && basePlayerBulletSO != null && basePlayerSpecialBulletSO != null)
        {
            playerStatSO = Instantiate(basePlayerStatSO);
            playerBulletSO = Instantiate(basePlayerBulletSO);
            playerSpecialBulletSO = Instantiate(basePlayerSpecialBulletSO);
        }
        
        currentStat = new CharacterStat
        {
            characterStatSO = playerStatSO,
            bulletSO = playerBulletSO,
            specialBulletSO = playerSpecialBulletSO
        };

        
        
        desc = basePlayerStatSO.str;
        id = basePlayerStatSO.id;
        gage = basePlayerStatSO.specialGage;
        
        //기본 스텟
        speed = basePlayerStatSO.MoveSpeed;
        maxHp = basePlayerStatSO.MaxHP;
        damage = basePlayerBulletSO.damage;
        duration = basePlayerBulletSO.duration;
        Debug.Log(gage);
    }
}