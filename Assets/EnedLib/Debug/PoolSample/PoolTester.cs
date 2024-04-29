using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnedUtil
{
    public class PoolTester : MonoBehaviour
    {
        [SerializeField] private EnedPoolManager poolsMgr;
        [SerializeField] private string key;
        [SerializeField] private GameObject sample;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                GetDummy();
            }
        }

        private void GetDummy()
        {
            PoolableSample currentSample =  this.poolsMgr.GetObject(key, () => 
            {
                IPoolable ipoolable = Instantiate(this.sample).GetComponent<IPoolable>();
                return ipoolable;
            }) as PoolableSample;

            currentSample.Activate();
        }
    }
}