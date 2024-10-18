using UnityEngine;
public class TopDownCharginging : MonoBehaviour
{
    [SerializeField] private Transform BulletSpawnPoint;
    private CharacterStatHandler characterStat;
    private DodgeController controller;
    private Vector2 shootDirection = Vector2.up;

    private void Awake()
    {
        controller = GetComponent<DodgeController>();
        characterStat= GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        controller.OnLookEvent += Aim2;
        controller.OnChargeEvent += Charging;
    }

    private void Charging(BulletSO bulletSO, double chargeGage)
    {
        BulletSO bSO = bulletSO as BulletSO;
        if (bulletSO == null) return;
        
        CreateProjectileCharge(bSO, chargeGage);
    }

    private void Aim2(Vector2 direction)//���� �޾ƿ���
    {
        shootDirection = direction;
    }

    private void CreateProjectile(BulletSO bulletSO)
    {
        GameObject b = Instantiate(bulletSO.bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg));
        ProjectileController attackController = b.GetComponent<ProjectileController>();
        attackController.InitiateAttack(shootDirection, bulletSO); //�⺻ ���ݸ� �ִٰ� ����, ������ ������ �������� ����
    }
    private void CreateProjectileCharge(BulletSO bulletSO, double chargeGage)
    {
        GameObject b = Instantiate(bulletSO.specialbulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg));
        ProjectileController attackController = b.GetComponent<ProjectileController>();
        attackController.chargeAttack(shootDirection, bulletSO, chargeGage);
    }
}