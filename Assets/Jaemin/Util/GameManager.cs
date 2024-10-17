using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ObjectPool;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //GameManager�� �ٸ� ������ ���� ���ٰ���
    [SerializeField ]private string playerTag;

    public Transform Player { get; private set; } //�б�� ���������� �ٸ� ������ �ʱ�ȭ �Ұ���

    public ObjectPool Pool {  get; private set; } //�б�� ���������� �ٸ� ������ �ʱ�ȭ �Ұ���

    [Header("GameUI")]
    [SerializeField] private TextMeshProUGUI currentScoreTxt;//���� ����
    [SerializeField] private TextMeshProUGUI highScoreTxt; //�ְ� ����
    [SerializeField] private TextMeshProUGUI playTime; //�ְ� ����
    private float time=0f;
    private float highTime = 0;

    [Header("PlayeeHp")]
    public Slider playerHpSlider; //HealthSystem���� �����Ͽ� �����Ű��

    [Header("Score")]
    public float currentScore;//���� ����
    public float highScore;//�ְ� ����
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

    private void Update()
    {
        time += Time.deltaTime;
        playTime.text = $"Time : {time:F2}";
    }

    public void Score()
    {
        //���� �׾��� �� ������ �޾ƿ��� ����
    }
  

    
}
