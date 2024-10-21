using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    // ��ư ������ ���� �ʵ�
    public Button playerBlueButton;
    public Button playerRedButton;
    public Button loadS;

    void Start()
    {
        // GameManager�� �ν��Ͻ��� ������
        GameManager gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            return;
        }

        // ��ư�� �̺�Ʈ ������ �߰�
        if (playerBlueButton != null)
        {
            playerBlueButton.onClick.RemoveAllListeners(); // ���� �̺�Ʈ ������ ����
            playerBlueButton.onClick.AddListener(gameManager.PlayerBlue); // PlayerBlue �޼��� ����
        }

        if (playerRedButton != null)
        {
            playerRedButton.onClick.RemoveAllListeners(); // ���� �̺�Ʈ ������ ����
            playerRedButton.onClick.AddListener(gameManager.PlayerRed); // PlayerRed �޼��� ����
        }

        if(loadS != null)
        {
            loadS.onClick.RemoveAllListeners(); // ���� �̺�Ʈ ������ ����
            loadS.onClick.AddListener(gameManager.PlayerClear); // PlayerBlue �޼��� ����
        }
    }

}
