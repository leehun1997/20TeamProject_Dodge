using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPool;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //GameManager�� �ٸ� ������ ���� ���ٰ���
    [SerializeField ]private string playerTag;

    public Transform Player { get; private set; } //�б�� ���������� �ٸ� ������ �ʱ�ȭ �Ұ���

    public ObjectPool Pool {  get; private set; } //�б�� ���������� �ٸ� ������ �ʱ�ȭ �Ұ���

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //�� ��ȯ �Ŀ���  GameManager �����ϱ� ����
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Player�ʱ�ȭ
        Player = GameObject.FindGameObjectWithTag(playerTag).transform; //PlayerTag�� �´� tag�� ������ �ִ� ������Ʈ�� transform������ Palyer�� �־��ش�/

        Pool = FindObjectOfType<ObjectPool>(); //�� �ȿ� ObjectPool �پ��ִ� ������Ʈ�� ã��Pool������ ������ �־� ���� �Ŵ������� ��Ǯ�� ���
    }
}
