using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.Manager
{
    public class DelayCallHelper : MonoBehaviour
    {
        static public DelayCallHelper Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public Coroutine DelayCall(float delayTime, bool condition, Action next, Action end)
        {
            return StartCoroutine(Cor_DelayCall(delayTime, condition, next, end));
        }

        public bool CancelCall(Coroutine coroutine)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                return true;
            }
            return false;
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