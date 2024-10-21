using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;

public abstract class EnemyController : DodgeController
{

    public Transform ClosesTarget { get; protected set; }
    protected HealthSystem _healthSystem;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        _healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
        ClosesTarget = GameManager.Instance.Player; // 게임매니저에 Player 가 있을시 가져오기
        
    }

    protected override void Update()
    {
        base.Update();
    }

    protected virtual void FixedUpdate()
    {
        
    }

    public virtual void Init() 
    {
        float addInitHP = statHandler.maxHp;
        if (statHandler.maxHp == _healthSystem.CurrentHp) 
        {
            addInitHP = 0;
        }
        _healthSystem.ChangeHP(addInitHP);
    }


    public float DistanceToTarget() 
    {
        return Vector2.Distance(transform.position, ClosesTarget.position);
    }

    public Vector2 DirectionToTarget() 
    {
        return (ClosesTarget.position - transform.position).normalized;
    }
}
