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

       /* while (onceChase)
        {
            Chase();
            
        }*/

    }

 

    private void ApplyDamage()
    {
        
    }

    private void Chase() 
    {
        Vector2 direction = Vector2.zero;

        direction = DirectionToTarget();

        CallMoveEvent(direction);
        Rotate(direction);
        onceChase = false;
        
    }

    private void Rotate(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        BombEnemyRenderer.flipY = Mathf.Abs(rotz) < 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

