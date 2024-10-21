using UnityEngine;
public class TopDownCharginging : MonoBehaviour
{
    [SerializeField] private Transform BulletSpawnPoint;
    private PlayerStatHandler playerStat;
    private DodgeController controller;
    private Vector2 shootDirection = Vector2.up;

    private GameObject b;
    private bool ready = false;
    private ProjectileController attackController;
    private ObjectPool pool;

    private void Awake()
    {
        controller = GetComponent<DodgeController>();
        playerStat= GetComponent<PlayerStatHandler>();
        pool = GameObject.FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        controller.OnLookEvent += Aim2;
        controller.OnChargeEvent += Charging;
    }

    private void Charging(BulletSO bulletSO,bool isCharging, double chargeGage)
    {
        Debug.Log($"player : {playerStat.id} check");
        switch (playerStat.id)
        {
            case 1: CreatePlayer1SpecailAttack(bulletSO, isCharging, chargeGage); return;
            case 2: CreatePlayer2SpecailAttack(bulletSO, isCharging, chargeGage); return;
                default: Debug.Log("ID index err."); return;
        }
    }

    private void Aim2(Vector2 direction)//���� �޾ƿ���
    {
        shootDirection = direction;
    }
    private void CreatePlayer1SpecailAttack(BulletSO bulletSO, bool isCharging, double chargeGage)
    {
        if (isCharging)
        {
            if (!ready)
            {
                ready = true;
                //b = Instantiate(bulletSO.bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg));
                b = pool.SpawnFromPool(bulletSO.bulletNameTag);
                b.transform.position = BulletSpawnPoint.transform.position;
                b.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);

                ProjectileController attackController = b.GetComponent<ProjectileController>();
                attackController.attackData = bulletSO;
            }
            else
            {
                Debug.Log("Charging!!!!!");
                b.transform.position = BulletSpawnPoint.transform.position;
                b.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);
                b.transform.localScale = Vector3.one * (float)chargeGage;
            }
        }
        else if(ready)
        {
            ready= false;
            attackController = b.GetComponent<ProjectileController>();
            attackController.player1ChargeAttack(shootDirection, bulletSO, chargeGage);
        }
    }
    private void CreatePlayer2SpecailAttack(BulletSO bulletSO, bool isCharging, double chargeGage)
    {
        b = pool.SpawnFromPool(bulletSO.bulletNameTag);
        b.transform.position = BulletSpawnPoint.transform.position;
        b.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);

        ProjectileController attackController = b.GetComponent<ProjectileController>();
        attackController.player2ChargeAttack(shootDirection, bulletSO, chargeGage);
    }
}