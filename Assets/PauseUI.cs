using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
   public void UnPause()
   {
      Time.timeScale = 1f;
   }
}
