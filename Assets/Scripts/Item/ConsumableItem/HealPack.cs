using UnityEngine;

public class HealPack : ConsumableItem
{
    private HealthSystem playerHP;

    [Header("HPPack Settings")] [SerializeField] [Range(1, 10)]
    private float HealAmount = 10f;


    protected override void Awake()
    {
        base.Awake();
        playerHP = Player.GetComponent<HealthSystem>();
    }


    protected override void UseConsumableItem()
    {
        playerHP.ChangeHP(HealAmount);
        Debug.Log("HEALPACK USED"); // 테스트용 추후 삭제
        Destroy(gameObject);
    }
}