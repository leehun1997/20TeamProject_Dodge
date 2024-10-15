using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("FollowCamera Settings")]
   [SerializeField] private Transform target;
    
    void Update()
    {
        Vector3 cameraPos = target.position + new Vector3(0, 0, -10f);
        transform.position = cameraPos;

    }
}
