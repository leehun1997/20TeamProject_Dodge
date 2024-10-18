using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public AudioClip buttonClickSound; // 버튼 클릭 소리를 가져올 변수
    private AudioSource audioSource;   // 오디오 소스 컴포넌트

    private void Start()
    {
        // 오디오 소스 컴포넌트를 가져오거나 없으면 추가
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        // 오디오 클립이 null이 아닌지 확인하고 재생
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
            StartCoroutine(LoadSceneAfterDelay(buttonClickSound.length));
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

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        // 딜레이 후 씬 전환
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("JaeMIn");
    }

}
