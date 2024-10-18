using UnityEngine;
public class TopDownCharginging : MonoBehaviour
{
    [SerializeField] private Transform BulletSpawnPoint;
    private PlayerStatHandler playerStat;
    private DodgeController controller;
    private Vector2 shootDirection = Vector2.up;

    private GameObject b;
    private BulletSO bulletSO;
    private bool ready = false;

    private void Awake()
    {
        controller = GetComponent<DodgeController>();
        playerStat= GetComponent<PlayerStatHandler>();
    }

    private void Start()
    {
        controller.OnLookEvent += Aim2;
        controller.OnChargeEvent += Charging;
    }

    private void Charging(bool isCharging, double chargeGage)
    {
        switch (playerStat.PlayerStatSo.id)
        {
            case 1: CreatePlayer1SpecailAttack(isCharging, chargeGage); return;
            case 2: CreatePlayer2SpecailAttack(isCharging, chargeGage); return;
                default: Debug.Log("ID index err."); return;
        }
    }

    private void Aim2(Vector2 direction)//���� �޾ƿ���
    {
        shootDirection = direction;
    }
    private void CreatePlayer1SpecailAttack(bool isCharging, double chargeGage)
    {        
        if (isCharging)
        {
            if (!ready)
            {
                ready= true;
                b = Instantiate(bulletSO.specialbulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg));
            }
            else
            {
                b.transform.localScale = Vector3.one * (float)chargeGage;
            }
        }
        bulletSO = playerStat.PlayerBulletSo;        
        ProjectileController attackController = b.GetComponent<ProjectileController>();
        attackController.chargeAttack(shootDirection, bulletSO, chargeGage);
    }
    private void CreatePlayer2SpecailAttack(bool isCharging, double chargeGage)
    {
        bulletSO = playerStat.PlayerBulletSo;
        b = Instantiate(bulletSO.specialbulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg));
        ProjectileController attackController = b.GetComponent<ProjectileController>();
        attackController.chargeAttack(shootDirection, bulletSO, chargeGage);
    }
}