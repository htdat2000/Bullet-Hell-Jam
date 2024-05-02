
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
        [SerializeField] private eShootingStyleType eShootingStyleType;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckShootingStyle();
                Shot();
            }
        }

        private void Shot()
        {
            this.currentShootingStyle.Trigger(this.gameObject, spawnBullet: (dir) => 
                SpawnBullet("Simple", this.bulletSample, dir));
        }

        protected virtual void SpawnBullet(string bulletKey, BasicBullet bulletSample, Vector2 _dir)
        {
            TheBullet currentSample =  this.poolManager.GetObject(bulletKey, () => 
                {
                    IPoolable ipoolable = Instantiate(bulletSample).GetComponent<IPoolable>();
                    return ipoolable;
                }) as TheBullet;
                currentSample.gameObject.transform.position = this.transform.position;
                currentSample.SetActive(true);

                currentSample.SetDir(_dir);
        }

        protected virtual void CheckShootingStyle()
        {
            switch (this.eShootingStyleType)
            {
                case eShootingStyleType.Simple:
                    this.currentShootingStyle = new SimpleShootingStyle();
                break;
                case eShootingStyleType.Trident:
                    this.currentShootingStyle = new TridentShootingStyle();
                break;
                case eShootingStyleType.Sequence:
                    this.currentShootingStyle = new SequenceShootingStyle();
                break;
                case eShootingStyleType.Circle:
                    this.currentShootingStyle = new CircleShootingStyle();
                break;
                case eShootingStyleType.MultiWay:
                    this.currentShootingStyle = new MultiWayShootingStyle();
                break;
            }
        }
    }
}
