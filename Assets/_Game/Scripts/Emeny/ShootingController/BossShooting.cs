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
                    shoot.ChangeBullet(bulletList[0]);
                    StartCoroutine(SequencesShoot());
                    currentShootCase++;
                    break;
                case 1:
                    shoot.ChangeBullet(bulletList[0]);
                    shoot.Shot(Vector2.down, eShootingStyleType.Circle);
                    currentShootCase++;
                    break;
                case 2:
                    StartCoroutine(SakuraBloom());
                    currentShootCase++;
                    break;
                case 3:
                    StartCoroutine(Shoot2());
                    currentShootCase++;
                    break;
                case 4:
                    shoot.ChangeBullet(bulletList[1]);
                    GameObject[] miniguns = GameObject.FindGameObjectsWithTag("Minigun");
                    foreach (GameObject minigun in miniguns)
                    {
                        minigun.GetComponent<Shooter>().Shot(Vector2.up, eShootingStyleType.Spread);
                    }
                    currentShootCase++;
                    break;
                default:
                    shoot.ChangeBullet(bulletList[0]);
                    shoot.Shot(Vector2.down, eShootingStyleType.Circle);
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
        IEnumerator SequencesShoot()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(1f);
                shoot.ChangeBullet(bulletList[1]);
                shoot.Shot(Vector2.down, eShootingStyleType.Sequence);
            }
        }
    }
}