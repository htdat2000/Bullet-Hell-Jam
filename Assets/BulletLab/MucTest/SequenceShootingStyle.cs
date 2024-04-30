using System;
using System.Collections;
using EnedUtil;
using UnityEngine;

namespace Bullet
{
    public class SequenceShootingStyle : ShootingStyle
    {
        public override void Trigger(BasicBullet bulletSample, EnedPoolManager poolManager, Action onShotFinish = null)
        {
            base.Trigger(bulletSample, poolManager);

            StartCoroutine(DoSequenceShoot(bulletSample, poolManager, onShotFinish));            
        }

        private IEnumerator DoSequenceShoot(BasicBullet bulletSample, EnedPoolManager poolManager, Action onShotFinish = null)
        {
            Vector2 currentDir = Vector2.down;
            for( int i = 0; i < 16; i++)
            {
                TheBullet currentSample =  this.poolManager.GetObject("Simple", () => 
                {
                    IPoolable ipoolable = Instantiate(bulletSample).GetComponent<IPoolable>();
                    return ipoolable;
                }) as TheBullet;

                currentSample.SetActive(true);
                currentSample.SetDir(currentDir);
                currentDir = GetRotatedVector(currentDir, Mathf.PI / 8);

                yield return new WaitForSeconds(0.2f);
            }

            if (onShotFinish != null) onShotFinish?.Invoke();
        }
    }
}