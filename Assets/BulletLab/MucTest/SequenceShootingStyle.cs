using System;
using System.Collections;
using EnedUtil;
using UnityEngine;

namespace Bullet
{
    public class SequenceShootingStyle : ShootingStyle
    {
        [SerializeField] protected int numberOfProjectiles = 16;
        [SerializeField] protected float cooldownTime = 0.2f;

        private int currentProjectiles = 0;
        Vector2 currentDir = Vector2.down;
        float angleStep => (2 * Mathf.PI) / numberOfProjectiles;

        public override void Trigger(GameObject shooter, 
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {
            CallRecursive(spawnBullet, onShotFinish);
            if (onShotFinish != null) onShotFinish?.Invoke();
        }

        private void CallRecursive(Action<Vector2> spawnBullet, Action onShotFinish)
        {
            ShootingSupporter.Instance.DelayCall(cooldownTime, currentProjectiles < numberOfProjectiles,
                next: () => {
                    currentProjectiles ++;
                    spawnBullet?.Invoke(currentDir);
                    currentDir = GetRotatedVector(currentDir, angleStep);
                    CallRecursive(spawnBullet, onShotFinish);
                },
                end: () =>{
                    currentProjectiles = 0;
                    Vector2 currentDir = Vector2.down;
                    onShotFinish?.Invoke();
                });
        }
    }

}