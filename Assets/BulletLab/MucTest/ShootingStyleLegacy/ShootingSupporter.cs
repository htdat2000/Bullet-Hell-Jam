using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Bullet
{
    public class ShootingSupporter : MonoBehaviour
    {
        public static ShootingSupporter Instance { get; private set; }
        private void Awake()
        {
            if (Instance != this)
                Instance = this;
        }

        public void DelayCall(float delayTime, bool condition, Action next, Action end)
        {
            StartCoroutine(Cor_DelayCall(delayTime, condition, next, end));
        }

        private IEnumerator Cor_DelayCall(float delayTime, bool condition, Action next, Action end)
        {
            yield return new WaitForSeconds(delayTime);
            if (condition)
            {
                next?.Invoke();
            }
            else
            {
                end?.Invoke();
            }
        }
    }
}