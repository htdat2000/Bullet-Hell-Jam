using EnedUtil;
using UnityEngine;

namespace MucDemo
{
    public class MucTheShootingStyle : MonoBehaviour
    {
        protected EnedPoolManager poolManager;
        public virtual void Trigger(BasicBullet basicBullet, EnedPoolManager poolManager)
        {
            this.poolManager = poolManager;
            //Do Something
        }
    }
}
