using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    private static DataManger instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    
    
    //여기서 SO에서 변경 될 데이터 들을 모아 놓고 관리? 
    private float playerSpeed; 
    

}
