using EnedUtil;
using UnityEngine;

namespace MucDemo
{
    public class MucTheSimpleShootingStyle : MucTheShootingStyle
    {
        public override void Trigger(BasicBullet bulletSample, EnedPoolManager poolManager)
        {
            base.Trigger(bulletSample, poolManager);
            MucTheBullet currentSample =  this.poolManager.GetObject("Simple", () => 
            {
                IPoolable ipoolable = Instantiate(bulletSample).GetComponent<IPoolable>();
                return ipoolable;
            }) as MucTheBullet;

            currentSample.SetActive(true);
            currentSample.SetDir(Vector2.down);
        }
    }
}