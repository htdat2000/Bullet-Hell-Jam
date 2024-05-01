
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnedUtil;

namespace Bullet
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private TheBullet bulletSample; //the bullet that will be shoot
        [SerializeField] private EnedPoolManager poolManager;
        [SerializeField] private ShootingStyle currentShootingStyle; //the way that the bullet is shooted

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.currentShootingStyle.Trigger(bulletSample, poolManager, this.gameObject);
            }
        }

        private void Shot(Vector2 dir)
        {

        }
    }
}
