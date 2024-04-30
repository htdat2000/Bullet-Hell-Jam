
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnedUtil;

namespace Bullet
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private TheBullet bulletSample;
        [SerializeField] private EnedPoolManager poolManager;
        [SerializeField] private ShootingStyle currentShootingStyle;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.currentShootingStyle.Trigger(bulletSample, poolManager);
            }
        }

        private void Shot(Vector2 dir)
        {

        }
    }
}
