using System;
using EnedUtil;
using UnityEngine;

namespace MucDemo
{
    public class MucTheShootingStyle : MonoBehaviour
    {
        protected EnedPoolManager poolManager;
        public virtual void Trigger(BasicBullet basicBullet, EnedPoolManager poolManager, Action onShotFinish = null)
        {
            this.poolManager = poolManager;
        }
        protected Vector2 GetRotatedVector(Vector2 startVector, float angleInRadians)
        {
            float newX = startVector.x * Mathf.Cos(angleInRadians) - startVector.y * Mathf.Sin(angleInRadians);
            float newY = startVector.x * Mathf.Sin(angleInRadians) + startVector.y * Mathf.Cos(angleInRadians);

            Vector2 result = new Vector2(newX, newY);
            return result;
        }
    }
}
