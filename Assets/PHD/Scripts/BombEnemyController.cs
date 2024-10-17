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
    private Vector3 playerPastPosition;
    private SpriteRenderer BombEnemyRenderer;
    Vector2 direction = Vector2.zero;
    public CharacterStatSO CSO;

    private bool isCollision;
    private bool onceChase = true;


    protected override void Start()
    {
        base.Start();
        // ## 헬스시스템 구독
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
        }

        if (Mathf.Abs(playerPastPosition.x - transform.position.x) < 0.1
            && Mathf.Abs(playerPastPosition.y - transform.position.y) < 0.1) {
            Destroy(gameObject, 0);
        }

    }

 

    private void ApplyDamage()
    {
        CharacterStatSO bombEnemyStatSO = statHandler.currentStat.characterStatSO;
        // EnemyStatSO bombEnemyStatSO1 = statHandler.currentStat.characterStatSO; 
        //EnemyStatSO 는 클래스고 currentStat.characterStatSO는 스크립터블오브젝트라 불가능
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
        
    }
}

