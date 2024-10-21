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
    [SerializeField] private string playerTag;
    public Transform Player { get; private set; } //읽기는 가능하지만 다른 곳에서 초기화 불가능
    public ObjectPool Pool { get; private set; } //읽기는 가능하지만 다른 곳에서 초기화 불가능

    [Header("GameUI")]
    [SerializeField] private TextMeshProUGUI currentTimeTxt; //현재 시간 테스트
    private float currentTime1 = 0f; //현재 시간
    private float highTime = 0f;//최고 시간
    private float lowTime = 0f; //가장 빨리 깬 시간을 저장
    private float currentTime2 = 0f; //현재 시간
    [Header("Score")]
    public float currentScore;//현재 점수
    public float highScore;//최고 점수

    [Header("PlayerSelect")]
    private GameObject playerPrefab;//Prefab불러오기
    private GameObject newPlayer; //플레이어 생성
    public GameObject PlayerSelectUI;//선택 UI
    public Slider playerHealthSlider; //플레이어가 소환될 때 slider 가져오기 위함

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //씬 전환 후에도  GameManager 유지하기 위해
            SceneManager.sceneLoaded += OnSceneLoaded;// 씬 로드 시 이벤트 등록
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Pool = FindObjectOfType<ObjectPool>(); //씬 안에 ObjectPool 붙어있는 오브젝트를 찾고Pool변수에 참조로 넣어 게임 매니저에서 그풀을 사용

 
    }

    private void Start()
    {
        Time.timeScale = 0f;
        playerPrefab = Resources.Load<GameObject>("Prefabs/PlayerBlue");//플레이어 선택을 위해 리소스에서 플레이어를 받아온다.
        LoadTimes(); // 최고 기록 및 최단 기록 불러오기
    }

    private void Update()
    {
        // 현재 씬에 따라 시간을 업데이트
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "InfiniteMap")
        {
            currentTime1 += Time.deltaTime;
            currentTimeTxt.text = $"Time : {currentTime1:F0}";
        }
        else if (currentSceneName == "StoryMap")
        {
            currentTime2 += Time.deltaTime;
            currentTimeTxt.text = $"Time : {currentTime2:F0}";
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        // 씬이 로드될 때 해당 씬의 시간 초기화
        if (sceneName == "InfiniteMap")
        {
            currentTime1 = 0f;
        }
        else if (sceneName == "StoryMap")
        {
            currentTime2 = 0f;
        }

        ReconnectUI();
        ReconnectPlayerSelectUI(); // PlayerSelectUI 재연결
    }

    private void ReconnectUI()
    {
        // PlayerUICanvas 하위의 Time 오브젝트를 찾아서 연결
        GameObject canvas = GameObject.Find("PlayerUICanvas");
        if (canvas != null)
        {
            Transform timeTransform = canvas.transform.Find("Time");
            if (timeTransform != null)
            {
                currentTimeTxt = timeTransform.GetComponent<TextMeshProUGUI>();
            }
        }

    }
    private void ReconnectPlayerSelectUI()
    {
        // PlayerSelectCanvas를 다시 찾습니다.
        GameObject playerSelectCanvas = GameObject.Find("PlayerSelectCanvas");
        if (playerSelectCanvas != null)
        {
            PlayerSelectUI = playerSelectCanvas;
        }

    }

    public void Score()
    {
        //몬스터 죽었을 때 점수를 받아오는 로직
    }

    public void PlayerTimeSave()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "InfiniteMap")
        {
            EndGameMap1(); // 최고 시간 저장
        }
        else if (currentSceneName == "StoryMap")
        {
            EndGameMap2(); // 최단 시간 저장
        }

        SceneManager.LoadScene("GameOver");
        //Time.timeScale = 0f;
    }

    public void PlayerClear()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "StoryMap")
        {
            EndGameMap2(); // 최단 시간 저장
        }

        SceneManager.LoadScene("GameClear");
    }

    public void EndGameMap1() //게임이 클리어했을 때
    {
        if (highTime == 0 || currentTime1 > highTime) // 현재 시간이 최고 시간보다 크면 갱신
        {
            highTime = currentTime1;
            SaveBestTime();
        }
    }

    public void EndGameMap2()
    {
        if (lowTime == 0 || currentTime2 < lowTime) // 현재 시간이 최단 시간보다 작으면 갱신
        {
            lowTime = currentTime2;
            SaveLowTime();
        }
    }

    private void SaveLowTime()// 빠른 점수라고해야하나
    {
        PlayerPrefs.SetFloat("LowTime", lowTime );
        PlayerPrefs.Save();
    }

    private void SaveBestTime() //기록 저장 높은 점수
    {
        PlayerPrefs.SetFloat("BestTime", highTime);
        PlayerPrefs.Save();
    }

    // 최고 기록 불러오기
    private void LoadTimes() // 최고 기록 및 최단 기록 불러오기
    {
        if (PlayerPrefs.HasKey("BestTime"))
        {
            highTime = PlayerPrefs.GetFloat("BestTime");
        }

        if (PlayerPrefs.HasKey("LowTime"))
        {
            lowTime = PlayerPrefs.GetFloat("LowTime");
        }
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
        if (playerPrefab != null)
        {
            newPlayer = Instantiate(playerPrefab);
            HealthSystem healthSystem = newPlayer.GetComponent<HealthSystem>();
            healthSystem.healthSlider = playerHealthSlider;
            Time.timeScale = 1f;
            Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        }

    }



}