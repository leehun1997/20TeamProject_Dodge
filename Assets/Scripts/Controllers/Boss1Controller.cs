using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss1Controller : EnemyController
{
    [SerializeField][Range(0f, 100f)] float walkTargetRange = 0f;
    [SerializeField][Range(0f, 100f)] float attackTargetRange = 0f;
    [SerializeField][Range(0, 20)] int collidingDamage = 0;
    [SerializeField][Range(0, 5)] int needCreateFrag = 0;
    private int collectingFrag = 0;
    private float raiderTime = 0f;
    public Transform ClosesFragment { get; protected set; }
    [SerializeField] private LayerMask Target; // ## ���� ����SO�� �ִٸ� ����
    private int layerMaskTarget;
    bool isfindFrag = false;
    private HealthSystem SupHealth;
    private ObjectPool objectPool;
    private BombEnemyController _bombEnemyController;
    [SerializeField] private GameObject bomberSpawnPivot;

    public event Action OnReady;

    protected override void Start()
    {
        base.Start();
        layerMaskTarget = Target;
        objectPool = GameObject.FindObjectOfType<ObjectPool>();
        // layerMaskTarget = ����SO.Target; ## ���� SO �ִٸ� ���
    }


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
        if (collectingFrag == needCreateFrag) 
        {
            OnReady?.Invoke();
            collectingFrag = 0;
        }
        raiderTime += Time.time;
        if (raiderTime > 1f) 
        {
            FindFragment();
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distanceToTarget = DistanceToTarget();
        Vector2 directionToTarget = DirectionToTarget();

        UpdateEnemyState(distanceToTarget, directionToTarget);


        if (ClosesFragment == null) { return; }
        float distanceToFragment = DistanceToFragment(ClosesFragment);
        Vector2 directionToFragment = DirectionToFragment(ClosesFragment);

        MoveToFragState(distanceToFragment, directionToFragment);
    }

    private void MoveToFragState(float distanceToTarget, Vector2 directionToTarget)
    {
            CallMoveEvent(directionToTarget);
            CallLookEvent(directionToTarget);
    }

    private void UpdateEnemyState(float distanceToTarget, Vector2 directionToTarget)
    {
        isAttacking = false;
        if (distanceToTarget < walkTargetRange)
        {
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
            //CallLookEvent(directionToTarget);
            //CallMoveEvent(directionToTarget);
        }
    }

    private void AttackPlayer(Vector2 directionToTarget)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, attackTargetRange, layerMaskTarget);

        Debug.DrawRay(transform.position, directionToTarget, Color.red);
        if (hit.collider != null)
        {
            
            isAttacking = true;
            //CallLookEvent(directionToTarget);
            //CallMoveEvent(Vector2.zero);
        }
        else
        {
            //CallMoveEvent(directionToTarget);
        }

    }

    private Vector2 DirectionToFragment(Transform ClosesFragment) 
    {
        

        return (ClosesFragment.position - transform.position).normalized;

    }

    private float DistanceToFragment(Transform ClosesFragment) 
    {
        return Vector2.Distance(transform.position, ClosesFragment.position);
    }


    private Transform FindFragment()
    {
            RaycastHit2D findFrag = Physics2D.CircleCast(transform.position, 15, transform.position);
            if (isfindFrag == true) { return ClosesFragment; }
            if (findFrag.collider.CompareTag("Fragment"))
            {
                ClosesFragment = findFrag.collider.transform;
                isfindFrag = true;
            }
            else
            {
                if (!isfindFrag)
                {
                    ClosesFragment = ClosesTarget;
                }

            }
        
        return ClosesFragment;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionTarget = collision.gameObject;

        if (collisionTarget.CompareTag("Player"))
        {
            SupHealth = collision.GetComponent<HealthSystem>();
            SupHealth.ChangeHP(-collidingDamage);
        }
        else if (collisionTarget.CompareTag("Fragment")) 
        {
            collisionTarget.SetActive(false);
            collectingFrag++;
            isfindFrag = false;
        }

    }

    public void CreateBombEnemy()
    {
        GameObject BombEnemyClone = objectPool.SpawnFromPool("BombEnemy");
        if (BombEnemyClone != null)
        {
            BombEnemyClone.transform.position = bomberSpawnPivot.transform.position;
            _bombEnemyController = BombEnemyClone.GetComponent<BombEnemyController>();
            _bombEnemyController.Init();
        }
    }
}
