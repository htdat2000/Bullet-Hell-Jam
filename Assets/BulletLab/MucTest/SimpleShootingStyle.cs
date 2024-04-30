using System;
using EnedUtil;
using UnityEngine;

namespace Bullet
{
    public class SimpleShootingStyle : ShootingStyle
    {
        public override void Trigger(BasicBullet bulletSample, EnedPoolManager poolManager, Action onShotFinish = null)
        {
            base.Trigger(bulletSample, poolManager);
            TheBullet currentSample =  this.poolManager.GetObject("Simple", () => 
            {
                IPoolable ipoolable = Instantiate(bulletSample).GetComponent<IPoolable>();
                return ipoolable;
            }) as TheBullet;

            currentSample.SetActive(true);
            currentSample.SetDir(Vector2.down);

            if (onShotFinish != null) onShotFinish?.Invoke();
        }
    }
}