using UnityEngine;

public class GagePack : ConsumableItem
{

    
    [Header("GagePack Settings")] 
    [SerializeField] [Range(1, 10)] private int gageUP = 10;
    GageSystem gageSystem;
    
    
    protected override void Awake()
    {
        base.Awake();
        gageSystem = Player.GetComponent<GageSystem>();
    }
    
    protected override void UseConsumableItem()
    {

        //게이지 올리는 로직 처리 
        // ->
        gageSystem.ChangeGage(gageUP);
        gameObject.SetActive(false);
    }
    
}