using UnityEngine;

public class GagePack : ConsumableItem
{

    
    [Header("GagePack Settings")] 
    [SerializeField] [Range(1, 10)] private int gageUP = 10;
    PlayerInputController inputController;
    
    
    protected override void Awake()
    {
        base.Awake();
        inputController = FindAnyObjectByType<PlayerInputController>();
    }
    
    protected override void UseConsumableItem()
    {

        //게이지 올리는 로직 처리 
        // ->
        inputController.currentGage += gageUP;
        gameObject.SetActive(false);
    }
    
}