using System.Collections;
using System.Collections.Generic;
using EnedUtil;
using UnityEngine;
using System;

namespace Bullet
{
    public class CircleShootingStyle : ShootingStyle
    {
        [SerializeField] protected int numberOfProjectiles = 16;
        
        public override void Trigger(BasicBullet bulletSample, EnedPoolManager poolManager, GameObject shooter, Action onShotFinish = null)
        {
           base.Trigger(bulletSample, poolManager, shooter);
           if (numberOfProjectiles == 0)
            {
                numberOfProjectiles = 16;
            }

            float angleStep = 360 / numberOfProjectiles * (Mathf.PI / 180);
            Vector2 currentDir = Vector2.down;

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                SpawnBullet("Simple", bulletSample, currentDir, shooter);
                currentDir = GetRotatedVector(currentDir, angleStep);
            }
        }
    }
}