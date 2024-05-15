using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.Manager
{
    public class LevelManager : MonoBehaviour
    {
        protected void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Event.GameEvents.OnWaveStart?.Invoke();
            }
        }
    }
}