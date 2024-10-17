using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    private void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("jaeMin");
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



}
