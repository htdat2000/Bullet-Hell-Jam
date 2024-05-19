using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BossShooting : ShootingController
    {
        [SerializeField] TheBullet[] bulletList;
        
        [Header("Sakura Bloom")]
        protected bool shoot1Finish = false;

        protected int currentShootCase = 0;
        
        protected override void Start()
        {
            base.Start();
            
        }
        protected override void ShootingConcept(Vector2 _dir, eShootingStyleType _eShootingStyleType)
        {
            switch (currentShootCase)
            {
                case 0:
                    shoot.Shot(Vector2.down, eShootingStyleType.Sequence);
                    currentShootCase++;
                    break;
                case 1: 
                    StartCoroutine(SakuraBloom());
                    currentShootCase++;
                    break;
                default:
                    shoot.Shot(Vector2.down, eShootingStyleType.MultiWay);
                    currentShootCase = 0;
                    break;
            }
        }
        IEnumerator SakuraBloom()
        {
            StartCoroutine(Shoot1());
            yield return new WaitUntil(() => shoot1Finish = true);
            StartCoroutine(Shoot2());
        }
        IEnumerator Shoot1()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.3f);
                shoot.ChangeBullet(bulletList[0]);
                shoot.Shot(Vector2.down, eShootingStyleType.Circle);
            }
            shoot1Finish = true;
        }
        IEnumerator Shoot2()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.3f);
                shoot.ChangeBullet(bulletList[1]);
                shoot.Shot(Vector2.down, eShootingStyleType.Circle);
            }
            shoot1Finish = false;
        }
    }
}