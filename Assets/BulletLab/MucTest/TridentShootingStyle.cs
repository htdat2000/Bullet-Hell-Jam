using System;
using System.Collections.Generic;
using UnityEngine;


namespace Bullet
{
    public class TridentShootingStyle : ShootingStyle
    {
        public override void Trigger(GameObject shooter, 
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {
            List<Vector2> hardDirs = new();
            hardDirs.Add(Vector2.down);
            hardDirs.Add(GetRotatedVector(Vector2.down, Mathf.PI / 4));
            hardDirs.Add(GetRotatedVector(Vector2.down, Mathf.PI / -4));

            for (int i = 0; i < 3; i++)
            {
                if (spawnBullet != null) spawnBullet?.Invoke(hardDirs[i]);
            }

            if (onShotFinish != null) onShotFinish?.Invoke();
        }
    }
}