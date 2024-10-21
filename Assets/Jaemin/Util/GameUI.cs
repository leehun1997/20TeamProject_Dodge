using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("토글 오브젝트")]
    public GameObject object1;
    public GameObject object2;

    [Header("오디오 관련")]
    public AudioClip buttonClickSound; // 버튼 클릭 소리를 가져올 변수
    private AudioSource audioSource;   // 오디오 소스 컴포넌트

    [Header("최고점수,시간")]
    [SerializeField] private TextMeshProUGUI highTimeTxt;
    [SerializeField] private TextMeshProUGUI lowTimeTxt;

    private void Start()
    {
        // 오디오 소스 컴포넌트를 가져오거나 없으면 추가
        audioSource = gameObject.GetComponent<AudioSource>();
        //PlayerPrefs.DeleteKey("LowTime");
        LoadBestTime();
        LoadLowTime();
    }
    public void StartGame(string sceneName)
    {
        // 오디오 클립이 null이 아닌지 확인하고 재생
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
            StartCoroutine(LoadSceneAfterDelay(sceneName, buttonClickSound.length));
        }
        else
        {
            Debug.LogWarning("No audio clip assigned for button click sound!");
        }
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        // 에디터에서 실행 중일 때는 플레이 모드를 종료합니다.
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            // 빌드된 게임에서 실행 중일 때는 게임을 종료합니다.
            Application.Quit();
        #endif
    }

    private IEnumerator LoadSceneAfterDelay(string SceneName, float delay)
    {
        // 딜레이 후 씬 전환
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 0f;
    }

    public void Toggle()
    {
        // 오브젝트의 활성화 상태를 반대로 설정
        if (object1.activeSelf)
        {
            object1.SetActive(false);
            object2.SetActive(true);
        }
        else
        {
            object1.SetActive(true);
            object2.SetActive(false);
        }
    }
        
    private void LoadBestTime()
    {
        if (PlayerPrefs.HasKey("BestTime"))
        {
            float highTime = PlayerPrefs.GetFloat("BestTime");
            highTimeTxt.text = $"High Time: {highTime:F0} (s)";
        }
        else
        {
            highTimeTxt.text = "No Time Recorded";
        }
    }

    private void LoadLowTime()
    {
        if (PlayerPrefs.HasKey("LowTime"))
        {
            float lowTime = PlayerPrefs.GetFloat("LowTime");
            lowTimeTxt.text = $"Low Time: {lowTime:F0} (s)";
        }
        else
        {
            lowTimeTxt.text = "No Time Recorded";
        }
    }

}
