using System;
using EnedUtil;
using UnityEngine;

namespace Bullet
{
    public class ShootingStyle : MonoBehaviour
    {
        protected EnedPoolManager poolManager;
        public virtual void Trigger(BasicBullet basicBullet, EnedPoolManager poolManager, GameObject shooter, Action onShotFinish = null)
        {
            this.poolManager = poolManager;
        }
        protected Vector2 GetRotatedVector(Vector2 startVector, float angleInRadians)
        {
            float newX = startVector.x * Mathf.Cos(angleInRadians) - startVector.y * Mathf.Sin(angleInRadians);
            float newY = startVector.x * Mathf.Sin(angleInRadians) + startVector.y * Mathf.Cos(angleInRadians);

            Vector2 result = new Vector2(newX, newY).normalized;
            return result;
        }
        protected virtual void SpawnBullet(string bulletKey, BasicBullet bulletSample, Vector2 _dir, GameObject shooter)
        {
            TheBullet currentSample =  this.poolManager.GetObject(bulletKey, () => 
                {
                    IPoolable ipoolable = Instantiate(bulletSample).GetComponent<IPoolable>();
                    return ipoolable;
                }) as TheBullet;
                currentSample.gameObject.transform.position = shooter.transform.position;
                currentSample.SetActive(true);

                currentSample.SetDir(_dir);
        }
    }
}
