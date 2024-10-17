using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    

    private bool isCollision = false;
    private bool onceChase = true;


    protected override void Start()
    {
        base.Start();
        SupHealth = GetComponent<HealthSystem>();
        playerPastPosition = ClosesTarget.position;
        BombEnemyRenderer = GetComponentInChildren<SpriteRenderer>();
        
        Chase();

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        

        if (isCollision) 
        {
            ApplyDamage();
            Destroy(gameObject, 0f);
            Debug.Log(SupHealth.CurrentHp);
        }

        if (Mathf.Abs(playerPastPosition.x - transform.position.x) < 0.1
            && Mathf.Abs(playerPastPosition.y - transform.position.y) < 0.1) {
            Destroy(gameObject, 0f);
        }

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
        onceChase = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (!player.CompareTag(targetTag)) { return; }
        SupHealth = collision.GetComponent<HealthSystem>();
        isCollision = true;

    }
}

