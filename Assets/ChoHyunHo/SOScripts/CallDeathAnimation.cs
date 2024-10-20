using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CallDeathAnimation : MonoBehaviour
{
    SpawnerEnemy Spawner;


    private void Awake()
    {
        Spawner = GameObject.FindObjectOfType<SpawnerEnemy>();
    }

    private void OnDisable()//�ｺ �ý���OnDeath�� ������ DestroyOnDeath.OnDeath()���� ���ش�
    {
        //������Ʈ Ǯ���� ������ ��ü���� �̸���(Clone)�� �ٴ´� �̰� ������ ����� �̸��� ����Ѵ�
        //������ ��ġ, ������ �����ϰ� �ϱ����� tranform�� �Ű������� �����Ѵ�
        Spawner.CreateDeathAnimation(gameObject.name.Remove(name.Length - 7), gameObject.transform);
    }
}
