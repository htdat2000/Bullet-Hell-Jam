using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnedUtil
{
    public class PoolableSample : MonoBehaviour, IPoolable
    {
        private bool isActivating = false;
        private void Start()
        {
            Activate();
        }

        public void Activate()
        {
            this.gameObject.SetActive(true);
            isActivating = true;
            StartCoroutine(DelayDeactive());
        }

        private IEnumerator DelayDeactive()
        {
            yield return new WaitForSeconds(3f);
            this.isActivating = false;
            this.gameObject.SetActive(false);
        }

        public bool IsActivating() {return this.isActivating;}
    }
}