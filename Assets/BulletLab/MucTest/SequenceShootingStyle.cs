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

        public override void Trigger(GameObject shooter, 
            Action<Vector2> spawnBullet, Action onShotFinish = null)
        {
            StartCoroutine(DoSequenceShoot(spawnBullet, shooter));
            if (onShotFinish != null) onShotFinish?.Invoke();
        }

        private IEnumerator DoSequenceShoot(Action<Vector2> spawnBullet, GameObject shooter)
        {
            if (numberOfProjectiles == 0)
            {
                numberOfProjectiles = 16;
            }

            float angleStep = 360 / numberOfProjectiles * (Mathf.PI / 180);
            Vector2 currentDir = Vector2.down;

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                if (spawnBullet != null) spawnBullet?.Invoke(currentDir);
                currentDir = GetRotatedVector(currentDir, angleStep);

                yield return new WaitForSeconds(cooldownTime);
            }
        }

    }

}