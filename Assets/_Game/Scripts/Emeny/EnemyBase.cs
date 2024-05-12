using Bullet.Manager;
using DG.Tweening;
using UnityEngine;

namespace Bullet.Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        private Vector2 endPoint;
        public virtual void Move(eAppearanceMovement eAppearanceMovement)
        {
            //Raining drop movement
            this.transform.position = this.endPoint + Vector2.up * 10f; 
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
