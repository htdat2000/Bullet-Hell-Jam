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
            hardDirs.Add(shootDir);
            hardDirs.Add(GetRotatedVector(shootDir, Mathf.PI / 4));
            hardDirs.Add(GetRotatedVector(shootDir, Mathf.PI / -4));

            for (int i = 0; i < 3; i++)
            {
                spawnBullet?.Invoke(hardDirs[i]);
            }

            onShotFinish?.Invoke();
        }
    }
}