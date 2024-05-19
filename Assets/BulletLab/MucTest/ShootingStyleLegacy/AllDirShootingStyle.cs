using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bullet
{
    public class AllDirShootingStyle : ShootingStyle
    {
        protected float cooldownTime = 0.2f;

        protected int numberOfProjectiles = 30;
        protected int currentProjectiles = 0;

        protected int minDir;
        protected int maxDir;

        Vector2 currentDir = Vector2.down;

        public override void Trigger(GameObject shooter,
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {
            currentDir = shootDir;

            CallRecursive(spawnBullet, onShotFinish);

            onShotFinish?.Invoke();
        }
        private void CallRecursive(Action<Vector2> spawnBullet, Action onShotFinish)
        {
            ShootingSupporter.Instance.DelayCall(cooldownTime, currentProjectiles < numberOfProjectiles,
                next: () =>
                {
                    currentProjectiles++;
                    float newX = UnityEngine.Random.Range(-1.1f, 1.1f);
                    float newY = UnityEngine.Random.Range(-1.1f, 1.1f);
                    currentDir = new Vector2 (newX, newY).normalized;

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