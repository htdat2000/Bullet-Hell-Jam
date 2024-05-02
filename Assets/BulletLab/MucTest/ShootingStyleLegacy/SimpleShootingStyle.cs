using System;
using UnityEngine;

namespace Bullet
{
    public class SimpleShootingStyle : ShootingStyle
    {
        public override void Trigger(GameObject shooter, 
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {            
            if (spawnBullet != null) spawnBullet?.Invoke(Vector2.down);
            if (onShotFinish != null) onShotFinish?.Invoke();
        }
    }
}