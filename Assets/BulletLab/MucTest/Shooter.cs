
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
    }
}
