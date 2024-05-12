using DG.Tweening;
using UnityEngine;

namespace Bullet.Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        private Vector2 endPoint;
        public virtual void Move()
        {
            this.transform.DOMove(endPoint, 0.5f);
        }
        public void SetStartPoint(Vector2 startPoint)
        {
            this.transform.position = startPoint;
        }
        public void SetEndPoint(Vector2 endPoint)
        {
            this.endPoint = endPoint;
        }
    }
}
