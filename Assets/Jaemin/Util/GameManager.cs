using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ObjectPool;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //GameManager를 다른 곳에서 쉽게 접근가능
    [SerializeField ]private string playerTag;

    public Transform Player { get; private set; } //읽기는 가능하지만 다른 곳에서 초기화 불가능

    public ObjectPool Pool {  get; private set; } //읽기는 가능하지만 다른 곳에서 초기화 불가능

    [Header("GameUI")]
    [SerializeField] private TextMeshProUGUI currentScoreTxt;//현재 점수
    [SerializeField] private TextMeshProUGUI highScoreTxt; //최고 점수
    [SerializeField] private TextMeshProUGUI playTime; //최고 점수
    private float time=0f; //현재 시간
    private float highTime = 0;//최고 시간

    [Header("Score")]
    public float currentScore;//현재 점수
    public float highScore;//최고 점수

    [Header("PlayerSelect")]
    private GameObject playerPrefab;//Prefab불러오기
    public GameObject PlayerSelectUI;//선택 UI
    private GameObject newPlayer; //플레이어 생성
    public Slider playerHealthSlider; //플레이어가 소환될 때 slider 가져오기 위함

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //씬 전환 후에도  GameManager 유지하기 위해
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Player초기화
        //Player = GameObject.FindGameObjectWithTag(playerTag).transform; //PlayerTag에 맞는 tag를 가지고 있는 오브젝트의 transform정보를 Palyer에 넣어준다/

        Pool = FindObjectOfType<ObjectPool>(); //씬 안에 ObjectPool 붙어있는 오브젝트를 찾고Pool변수에 참조로 넣어 게임 매니저에서 그풀을 사용
    }

    private void Start()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/PlayerBlue");//플레이어 선택을 위해 리소스에서 플레이어를 받아온다.
        Time.timeScale = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        playTime.text = $"Time : {time:F0}";
    }

    public void Score()
    {
        //몬스터 죽었을 때 점수를 받아오는 로직
    }

    public void PlayerBlue() //Blue를 골랐을 때
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/PlayerBlue");
        PlayerSelectUI.SetActive(false);
        PlayerChange();


    }

    public void PlayerRed() //Red를 골랐을 때
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/PlayerRed");
        PlayerSelectUI.SetActive(false);
        PlayerChange();
    }
  
    public void PlayerChange()
    {
        if(playerPrefab != null)
        {
           newPlayer = Instantiate(playerPrefab);
            HealthSystem healthSystem = newPlayer.GetComponent<HealthSystem>();
            healthSystem.healthSlider = playerHealthSlider;
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("플레이어가 없다");
        }
    }
    


}
