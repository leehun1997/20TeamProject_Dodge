using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    // 버튼 참조를 위한 필드
    public Button playerBlueButton;
    public Button playerRedButton;
    public Button loadS;

    void Start()
    {
        // GameManager의 인스턴스를 가져옴
        GameManager gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            return;
        }

        // 버튼에 이벤트 리스너 추가
        if (playerBlueButton != null)
        {
            playerBlueButton.onClick.RemoveAllListeners(); // 기존 이벤트 리스너 제거
            playerBlueButton.onClick.AddListener(gameManager.PlayerBlue); // PlayerBlue 메서드 연결
        }

        if (playerRedButton != null)
        {
            playerRedButton.onClick.RemoveAllListeners(); // 기존 이벤트 리스너 제거
            playerRedButton.onClick.AddListener(gameManager.PlayerRed); // PlayerRed 메서드 연결
        }

        if(loadS != null)
        {
            loadS.onClick.RemoveAllListeners(); // 기존 이벤트 리스너 제거
            loadS.onClick.AddListener(gameManager.PlayerClear); // PlayerBlue 메서드 연결
        }
    }

}
