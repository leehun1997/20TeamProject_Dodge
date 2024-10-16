using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BombEnemyController : EnemyController
{
    [SerializeField][Range(0f, 1000f)] float walkTargetRange = 0f;

    private bool isCollision;


    protected override void Start()
    {
        base.Start();
        // ## 헬스시스템 구독

        Vector2 direction = Vector2.zero;
        if (DistanceToTarget() < walkTargetRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction); //일부러 FixedUpdate에서 안부름 계속 쫓아다니면 너무 하드함

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (isCollision) 
        {
            ApplyDamage();
        }

    }

    private void ApplyDamage()
    {
        
    }
}

