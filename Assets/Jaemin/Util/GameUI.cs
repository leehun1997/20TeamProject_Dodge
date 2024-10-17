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
        // �����Ϳ��� ���� ���� ���� �÷��� ��带 �����մϴ�.
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            // ����� ���ӿ��� ���� ���� ���� ������ �����մϴ�.
            Application.Quit();
        #endif
    }



}
