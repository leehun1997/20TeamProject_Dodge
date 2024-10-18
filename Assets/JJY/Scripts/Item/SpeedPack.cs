using UnityEngine;

public class SpeedPack : ConsumableItem
{
    
    [Header("SpeedPack Settings")] 
    [SerializeField] [Range(1, 10)] private float speedUp = 10f;

    
    protected override void UseConsumableItem()
    {
        // TODO: CharacterStatHandler Update를 통해 처리로 변경 
        Player.GetComponent<CharacterMovement>().SetSpeedForTest(speedUp);
        Debug.Log("SPEEDPACK USED"); // 테스트용 추후 삭제
        Destroy(gameObject);
    }
}
