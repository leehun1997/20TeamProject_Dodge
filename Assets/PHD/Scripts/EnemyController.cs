using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemyController : DodgeController
{

    protected Transform ClosesTarget { get; private set; }
    public Transform Player { get; private set; } // ## 게임매니저에 있어야 할 부분
    string playertag = "Player"; // ## base.Awake 활성화시 삭제

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag(playertag).transform; // ## base.Awake 활성화시 삭제
    }

    // Update is called once per frame
    protected virtual void Start()
    {
        // ClosesTarget = GameManager.Instance.Player; // 게임매니저에 Player 가 있을시 가져오기
        ClosesTarget = Player; // ## 삭제해야할 부분
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
