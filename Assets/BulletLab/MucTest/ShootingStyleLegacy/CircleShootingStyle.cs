using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bullet
{
    public class CircleShootingStyle : ShootingStyle
    {
        [SerializeField] protected int numberOfProjectiles = 16;
        
        public override void Trigger(GameObject shooter, 
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {
            float angleStep = (2 * Mathf.PI) / (numberOfProjectiles - 1);
            Vector2 currentDir = shootDir;

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                spawnBullet?.Invoke(currentDir);
                currentDir = GetRotatedVector(currentDir, angleStep);
            }
            
            onShotFinish?.Invoke();
        }
    }
}