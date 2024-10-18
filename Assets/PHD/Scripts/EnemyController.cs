using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public abstract class EnemyController : DodgeController
{

    protected Transform ClosesTarget { get; private set; }

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
       ClosesTarget = GameManager.Instance.Player; // ���ӸŴ����� Player �� ������ ��������
       
    }

    protected override void Update()
    {
        base.Update();
    }

    protected virtual void FixedUpdate()
    {

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
