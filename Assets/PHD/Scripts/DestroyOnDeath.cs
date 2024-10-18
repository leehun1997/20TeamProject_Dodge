using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


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
            rigidbody.velocity = Vector2.zero;
            //Instantiate(PlayerAnimation, this.transform.position , transform.rotation); 애니메이션을 갖고있는 empty object를 생성 되고 / 디스트로이는 그 오브젝트만
            gameObject.SetActive(false);
        }
        else 
        {
            rigidbody.velocity = Vector2.zero;
            gameObject.SetActive(false);
        };
        
    }
}


