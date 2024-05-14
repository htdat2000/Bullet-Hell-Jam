using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bullet
{
    public class SpreadShootingStyle : ShootingStyle
    {
        protected float cooldownTime = 0.1f;

        protected int numberOfProjectiles = 100;
        protected int currentProjectiles = 0;

        protected Vector2 minDir;
        protected Vector2 maxDir;

        Vector2 currentDir = Vector2.down;

        public override void Trigger(GameObject shooter,
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {
            currentDir = shootDir;

            minDir = GetRotatedVector(currentDir, -MathF.PI / 6);
            maxDir = GetRotatedVector(currentDir, MathF.PI / 6);

            CallRecursive(spawnBullet, onShotFinish);

            onShotFinish?.Invoke();
        }
        private void CallRecursive(Action<Vector2> spawnBullet, Action onShotFinish)
        {
            ShootingSupporter.Instance.DelayCall(cooldownTime, currentProjectiles < numberOfProjectiles,
                next: () =>
                {
                    currentProjectiles++;

                    float newX = UnityEngine.Random.Range(minDir.x, maxDir.x);
                    float newY = UnityEngine.Random.Range(minDir.y, maxDir.y);
                    currentDir = new Vector2 (newX, newY);

                    spawnBullet?.Invoke(currentDir);
                    CallRecursive(spawnBullet, onShotFinish);
                },
                end: () =>
                {
                    currentDir = shootDir;
                    currentProjectiles = 0;
                    onShotFinish?.Invoke();
                });
        }
    }
}