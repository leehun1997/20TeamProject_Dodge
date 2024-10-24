﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem healthSystem;
    private Rigidbody2D rigidbody;
    [SerializeField] private string PlayerTag = "Player";
    private Animation PlayerAnimation;
    

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        rigidbody = GetComponent<Rigidbody2D>();
        healthSystem.OnDeath += OnDeath;
        PlayerAnimation = GetComponent<Animation>();
        //Aiming = GetComponent<CharacterAiming>();
    }

    private void OnDeath()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (this.CompareTag(PlayerTag))
        {
            //죽는 로직 : 플레이어가 죽었을 때 무한맵이면 시간 저장, 스토리면 그냥 restart로
            if (currentSceneName == "InfiniteMap")
            {
                GameManager.Instance.PlayerTimeSave(); //게임 시간 저장
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (this.CompareTag("Boss"))
        {
            //보스가 죽었을 때 스토리 모드 클리어 조건 달성
            if (currentSceneName == "StoryMap")
            {
                GameManager.Instance.PlayerTimeSave(); //게임 시간 저장
                SceneManager.LoadScene("GameClear");
            }
            else if (currentSceneName == "InfiniteMap")
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
            AudioManager.Instance.PlaySFX("EnemyDeath");
            gameObject.SetActive(false);
        }
    }
}


