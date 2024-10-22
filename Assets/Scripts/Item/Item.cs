using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;


//Player만 사용 가능하도록 설계 
public abstract class Item : MonoBehaviour
{
    [Header("Item Settings")] [Tooltip("아이템이 깜빡이기 시작하는 시간")] [SerializeField] [Range(1, 10)]
    private float startBlinkTime = 3f;

    [Tooltip("아이템이 깜빡이기 시작한 후 사라지는 시간")] [SerializeField] [Range(1, 10)]
    private float destroyTime = 5f;

    [Tooltip("아이템이 깜빡이는 간격")] [SerializeField] [Range(0, 1)]
    private float blinkInterval = 0.5f;

    protected CharacterStatHandler playerStat;
    protected Inventory inventory;
    protected Transform Player;

    public SpriteRenderer SpriteRenderer { get; private set; }

    public ItemName itemName; // 아이템의 이름을 지정하는 필드

    protected virtual void Awake()
    {
        Player = GameManager.Instance.Player; //추후 GameManger 혹은 DataManager 클래스에서 Player오브젝트 저장 후 가져오기도 가능
        playerStat = Player.GetComponent<CharacterStatHandler>();
        inventory = Player.GetComponent<Inventory>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    public void OnEnableItem()
    {
        Invoke(nameof(StartDestroyAfterTime), startBlinkTime);
    }


    private void StartDestroyAfterTime()
    {
        if (!gameObject.activeInHierarchy)
            return;
        
        
        
        StartCoroutine(DestroyAfterTime());
    }


    protected IEnumerator DestroyAfterTime()
    {
        float timePassed = 0f;

        while (timePassed < destroyTime)
        {
            Color currentColor = SpriteRenderer.color;
            currentColor.a = currentColor.a == 1f ? 0.2f : 1f;
            SpriteRenderer.color = currentColor;

            yield return new WaitForSeconds(blinkInterval);
            timePassed += blinkInterval;
        }

        gameObject.SetActive(false);
    }


    public abstract void UseItem();
}