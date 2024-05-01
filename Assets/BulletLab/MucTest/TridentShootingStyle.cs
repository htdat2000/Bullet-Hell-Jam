using System;
using System.Collections.Generic;
using EnedUtil;
using UnityEngine;


namespace Bullet
{
    public class TridentShootingStyle : ShootingStyle
    {
        public override void Trigger(BasicBullet bulletSample, EnedPoolManager poolManager, GameObject shooter, Action onShotFinish = null)
        {
            base.Trigger(bulletSample, poolManager, shooter);
            List<Vector2> hardDirs = new();
            hardDirs.Add(Vector2.down);
            hardDirs.Add(GetRotatedVector(Vector2.down, Mathf.PI / 4));
            hardDirs.Add(GetRotatedVector(Vector2.down, Mathf.PI / -4));

            for (int i = 0; i < 3; i++)
            {
                SpawnBullet("Simple", bulletSample, hardDirs[i], shooter);
            }

            if (onShotFinish != null) onShotFinish?.Invoke();
        }
    }
}