
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnedUtil;

namespace MucDemo
{
    public class MucTheShooter : MonoBehaviour
    {
        [SerializeField] private MucTheBullet bulletSample;
        [SerializeField] private EnedPoolManager poolManager;
        [SerializeField] private MucTheShootingStyle currentShootingStyle;

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
