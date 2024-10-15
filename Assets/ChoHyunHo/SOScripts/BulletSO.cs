using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "BulletSO/Default", order = 0)]

public class BulletSO : ScriptableObject
{
    [Header("���� �⺻ �Ѿ�����")]
    public LayerMask targetLayer;
    public float damage;
    public float size;
    public float speed;
    public float delay;

    public GameObject bulletPrefab;
    //�ǰ� ��� �Ѿ��� Layer�˻��ؼ� ���̸� damage����
}