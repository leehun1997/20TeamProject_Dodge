using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    private Button button;
    
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(Select);
    }

    public void Select()
    {
        AudioManager.Instance.PlaySFX("SelectSFX");
    }
    
}