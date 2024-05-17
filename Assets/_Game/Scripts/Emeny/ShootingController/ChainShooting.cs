using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class ChainShooting : ShootingController
    {
        protected float timeBetweenShoot = 0.2f;
        [SerializeField] protected float bulletQuantity = 3;
        protected float currentQuantity = 0;
        protected override void ShootingConcept(Vector2 _dir, eShootingStyleType _eShootingStyleType)
        {
            ShootingSupporter.Instance.DelayCall(timeBetweenShoot, currentQuantity < bulletQuantity,
            next: () =>
            {
                currentQuantity++;
                shoot.Shot(_dir, _eShootingStyleType);
                ShootingConcept(_dir, _eShootingStyleType);
            },
            end: () =>
            {
                currentQuantity = 0;
            }
            );
            
        }
    }
}