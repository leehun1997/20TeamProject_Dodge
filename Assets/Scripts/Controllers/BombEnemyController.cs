using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class BombEnemyController : EnemyController
{
    [SerializeField][Range(0f, 1000f)] float walkTargetRange = 0f;
    [SerializeField] private string targetTag = "Player";
    
    
    private Vector3 playerPastPosition;
    private SpriteRenderer BombEnemyRenderer;
    Vector2 direction = Vector2.zero;
    public CharacterStatSO CSO;
    private HealthSystem SupHealth;
    int i = 0;

    private bool isCollision = false;



    protected override void Start()
    {
        base.Start();

        playerPastPosition = ClosesTarget.position;
        BombEnemyRenderer = GetComponentInChildren<SpriteRenderer>();
        
        Chase();

    }

    protected override void Update()
    {
        base.Update();
        if (Mathf.Abs(playerPastPosition.x - transform.position.x) < 0.1
           && Mathf.Abs(playerPastPosition.y - transform.position.y) < 0.1)
        {
            _healthSystem.ChangeHP(-statHandler.maxHp);
            gameObject.SetActive(false);
        }
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Init() 
    {
        base.Init();
        SupHealth = GetComponent<HealthSystem>();
        if (ClosesTarget == null) 
        {
            ClosesTarget = GameManager.Instance.Player;
        }
        playerPastPosition = ClosesTarget.position;
        BombEnemyRenderer = GetComponentInChildren<SpriteRenderer>();
        Chase();
    }

    private void ApplyDamage()
    {
        //EnemyStatSO bombEnemyStatSO = statHandler.currentStat.characterStatSO as EnemyStatSO;
        SupHealth.ChangeHP(-20f);
        
    }

    private void Chase() 
    {
        direction = DirectionToTarget();

        CallMoveEvent(direction);
        CallLookEvent(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (!player.CompareTag(targetTag)) { return; }
        SupHealth = collision.GetComponent<HealthSystem>();

            ApplyDamage();
        _healthSystem.ChangeHP(-statHandler.maxHp);
            gameObject.SetActive(false);


    }

}

