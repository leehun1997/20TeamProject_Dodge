using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text currentScore;
    public Text highScore;
    public void ShowScore()
    {
        //currentScore = DataManger.score;
        //highScore = DataManger.highScore;
    }
    public void OnClickRetryBTN()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickCharacterSelectBTN()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }
    public void OnClickMainMenuBTN()
    {
        SceneManager.LoadScene("StartScene");
    }
}
