using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class RangeEnemyController : EnemyController
    {
    [SerializeField][Range(0f, 100f)] float walkTargetRange = 0f;
    [SerializeField][Range(0f, 100f)] float attackTargetRange = 0f;

    [SerializeField] private LayerMask Target; // ## 만약 스탯SO에 있다면 삭제
    private int layerMaskTarget;
    

    protected override void Start()
    {
        base.Start();
        layerMaskTarget = Target;
        // layerMaskTarget = 스탯SO.Target; ## 스탯 SO 있다면 사용
    }

    protected override void Awake()
    {
        
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate ()
    {
        base.FixedUpdate ();

        float distanceToTarget = DistanceToTarget();
        Vector2 directionToTarget = DirectionToTarget();

        UpdateEnemyState(distanceToTarget, directionToTarget);
    }

    private void UpdateEnemyState(float distanceToTarget, Vector2 directionToTarget)
    {
        isAttacking = false;
        if (distanceToTarget < walkTargetRange) {
            HowToAction(distanceToTarget, directionToTarget);
        }
    }

    private void HowToAction(float distanceToTarget, Vector2 directionToTarget)
    {
        if (distanceToTarget < attackTargetRange)
        {
            AttackPlayer(directionToTarget);
        }
        else 
        {
            CallLookEvent(directionToTarget);
            CallMoveEvent(directionToTarget);
        }
    }

    private void AttackPlayer(Vector2 directionToTarget)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, attackTargetRange, layerMaskTarget);

        Debug.DrawRay(transform.position, directionToTarget, Color.red);
        if (hit.collider != null)
        {
            
            isAttacking = true;
            CallLookEvent(directionToTarget);
            CallMoveEvent(Vector2.zero);
        }
        else 
        {
            CallMoveEvent(directionToTarget);
        }
    }
}

