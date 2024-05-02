using System;
using EnedUtil;
using UnityEngine;

namespace Bullet
{
    public class ShootingStyle : MonoBehaviour
    {
        protected GameObject timer;
        public virtual void Trigger(GameObject shooter, 
            Action<Vector2> spawnBullet, Action onShotFinish = null){}
        protected Vector2 GetRotatedVector(Vector2 startVector, float angleInRadians)
        {
            float newX = startVector.x * Mathf.Cos(angleInRadians) - startVector.y * Mathf.Sin(angleInRadians);
            float newY = startVector.x * Mathf.Sin(angleInRadians) + startVector.y * Mathf.Cos(angleInRadians);

            Vector2 result = new Vector2(newX, newY).normalized;
            return result;
        }
    }
}
