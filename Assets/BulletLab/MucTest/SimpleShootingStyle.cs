using System;
using EnedUtil;
using UnityEngine;

namespace Bullet
{
    public class SimpleShootingStyle : ShootingStyle
    {
        public override void Trigger(BasicBullet bulletSample, EnedPoolManager poolManager, GameObject shooter, Action onShotFinish = null)
        {
            base.Trigger(bulletSample, poolManager, shooter);
            
            SpawnBullet("Simple", bulletSample, Vector2.down, shooter);
            if (onShotFinish != null) onShotFinish?.Invoke();
        }
    }
}