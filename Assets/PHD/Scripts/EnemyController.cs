using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemyController : DodgeController
{

    protected Transform ClosesTarget { get; private set; }
    public Transform Player { get; private set; } // ## ���ӸŴ����� �־�� �� �κ�
    string playertag = "Player"; // ## base.Awake Ȱ��ȭ�� ����

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag(playertag).transform; // ## base.Awake Ȱ��ȭ�� ����
    }

    // Update is called once per frame
    protected virtual void Start()
    {
        // ClosesTarget = GameManager.Instance.Player; // ���ӸŴ����� Player �� ������ ��������
        ClosesTarget = Player; // ## �����ؾ��� �κ�
    }

    protected virtual void Update()
    {

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
