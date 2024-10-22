using UnityEngine;

public class GagePack : ConsumableItem
{

    
    [Header("GagePack Settings")] 
    [SerializeField] [Range(1, 10)] private int gageUP = 10;
    
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    protected override void UseConsumableItem()
    {
        
        //게이지 올리는 로직 처리 
        // ->
        gameObject.SetActive(false);
    }
    
}