using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public AudioClip buttonClickSound; // ��ư Ŭ�� �Ҹ��� ������ ����
    private AudioSource audioSource;   // ����� �ҽ� ������Ʈ

    private void Start()
    {
        // ����� �ҽ� ������Ʈ�� �������ų� ������ �߰�
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        // ����� Ŭ���� null�� �ƴ��� Ȯ���ϰ� ���
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
        // �����Ϳ��� ���� ���� ���� �÷��� ��带 �����մϴ�.
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            // ����� ���ӿ��� ���� ���� ���� ������ �����մϴ�.
            Application.Quit();
        #endif
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        // ������ �� �� ��ȯ
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("JaeMIn");
    }

}
