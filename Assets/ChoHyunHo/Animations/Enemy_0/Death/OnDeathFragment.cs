using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OnDeathFragment : MonoBehaviour
{
    [Header("ĳ���� ������ �´� ������ �ڽ�ȭ �� �� ���")]
    [SerializeField] List<GameObject> fragmentPrefabs;

    private SpriteRenderer SpriteRenderer;

    private GameObject newObj;

    private float RandNum;
    private Vector2 makePosition;
    private int count = 0;

    public event Action OnDeathAnimationEnd; 
    
    

    private void Awake()
    {
        SpriteRenderer=GetComponent<SpriteRenderer>();
    }

    //Enemy_0_Death�ִϸ�����>Death�ִϸ��̼�>Add Animation Event���� ȣ���
    public void DeathAnimationEnd()
    {
        SpriteRenderer.enabled = false;
        InstancePrefabs();
        OnDeathAnimationEnd?.Invoke();
    }
    private void InstancePrefabs()//�ν����Ϳ��� ��ϵ� ���������յ� ��üȭ
    {
        foreach (var obj in fragmentPrefabs)
        {
            RandNum = Random.Range(0f, 360f);
            newObj = Instantiate(obj, transform);
            obj.transform.localRotation = Quaternion.Euler(0, 0, RandNum);
        }
        
     }

    public void FragmentDisable()//�ڽ��� ������� ��Ȱ��ȭ(����)�Ǹ� ȣ��
    {
        count += 1;
        if (count >= fragmentPrefabs.Count)//��� ������ ��Ȱ��ȭ(����)�Ǹ� ���� ������on, gameObject��Ȱ��ȭ
        {
            SpriteRenderer.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
