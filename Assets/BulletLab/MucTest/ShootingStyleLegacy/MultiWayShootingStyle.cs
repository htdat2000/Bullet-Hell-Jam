using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bullet
{
    public class MultiWayShootingStyle : ShootingStyle
    {
        [SerializeField] protected int numberOfProjectiles = 4;
    
        public override void Trigger(GameObject shooter, 
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {
            float angleStep = 90 / (numberOfProjectiles - 1) * (Mathf.PI / 180);
            Vector2 currentDir = GetTheStartWayDir();

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                spawnBullet.Invoke(currentDir);
                currentDir = GetRotatedVector(currentDir, angleStep);
            }

            onShotFinish?.Invoke();
        }
        protected Vector2 GetTheStartWayDir()
        {
            Vector2 currentDir = shootDir;
            currentDir = GetRotatedVector(currentDir, -MathF.PI/4);
            return currentDir;
        }
    }
}