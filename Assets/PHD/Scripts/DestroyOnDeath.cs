using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem healthSystem;
    private Rigidbody2D rigidbody;
    [SerializeField] private string targetTag = "Player";
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
        if (this.CompareTag(targetTag))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            //죽는 로직 : 플레이어가 죽었을 때 무한맵이면 시간 저장, 스토리면 그냥 restart로
            if (currentSceneName == "InfiniteMap")
            {
                GameManager.Instance.PlayerTimeSave(); //게임 시간 저장
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
            
        }
        else 
        {
            rigidbody.velocity = Vector2.zero;
            gameObject.SetActive(false);
        };
        
    }
}


