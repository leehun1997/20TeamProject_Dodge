using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("��� ������Ʈ")]
    public GameObject object1;
    public GameObject object2;

    [Header("����� ����")]
    public AudioClip buttonClickSound; // ��ư Ŭ�� �Ҹ��� ������ ����
    private AudioSource audioSource;   // ����� �ҽ� ������Ʈ

    [Header("�ְ�����,�ð�")]
    [SerializeField] private TextMeshProUGUI highTimeTxt;
    [SerializeField] private TextMeshProUGUI lowTimeTxt;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        // ����� �ҽ� ������Ʈ�� �������ų� ������ �߰�
        audioSource = gameObject.GetComponent<AudioSource>();
        //PlayerPrefs.DeleteKey("LowTime");
        LoadBestTime();
        LoadLowTime();
        LoadHighScore();
    }
    public void StartGame(string sceneName)
    {
        // ����� Ŭ���� null�� �ƴ��� Ȯ���ϰ� ���
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
        // �����Ϳ��� ���� ���� ���� �÷��� ��带 �����մϴ�.
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            // ����� ���ӿ��� ���� ���� ���� ������ �����մϴ�.
            Application.Quit();
        #endif
    }

    private IEnumerator LoadSceneAfterDelay(string SceneName, float delay)
    {
        // ������ �� �� ��ȯ
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 0f;
    }

    public void Toggle()
    {
        // ������Ʈ�� Ȱ��ȭ ���¸� �ݴ�� ����
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

    private void LoadHighScore()
    {
        // GameManager의 Instance를 통해 최고 점수를 가져옴
        if (GameManager.Instance != null)
        {
            float highScore = GameManager.Instance.highScore;
            highScoreText.text = $"High Score: {highScore:F0}";
        }
        else
        {
            highScoreText.text = "No Score Recorded";
        }
    }
}