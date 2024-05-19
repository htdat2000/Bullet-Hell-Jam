
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnedUtil;
using Event;

namespace Bullet
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private TheBullet bulletSample; //the bullet that will be shoot
        [SerializeField] private EnedPoolManager poolManager;
        [SerializeField] private ShootingStyle currentShootingStyle; //the way that the bullet is shooted
        [SerializeField] private eShootingStyleType eShootingStyleType;

        [SerializeField] protected float shootCooldownTime = 1;
        protected float shootCooldown = 1;

        protected bool isWaveStarted = false;

        protected void Start()
        {
            GameEvents.OnWaveStart += OnWaveStart;
            CheckShootingStyle();
        }
        protected void OnDisable()
        {
            GameEvents.OnWaveStart -= OnWaveStart;
        }
        public void Shot(Vector2 _dir, eShootingStyleType _eShootingStyleType = eShootingStyleType.Unknown)
        {
            if (_eShootingStyleType != eShootingStyleType.Unknown)
            {
                eShootingStyleType = _eShootingStyleType;
                CheckShootingStyle();
            }
            this.currentShootingStyle.SetShootDir(_dir);
            this.currentShootingStyle.Trigger(this.gameObject, spawnBullet: (dir) =>
                SpawnBullet("Simple", this.bulletSample, dir));
        }

        protected virtual void SpawnBullet(string bulletKey, TheBullet bulletSample, Vector2 _dir)
        {
            TheBullet currentSample = this.poolManager.GetObject(bulletKey, () =>
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
                case eShootingStyleType.Spread:
                    this.currentShootingStyle = new SpreadShootingStyle();
                    break;
                case eShootingStyleType.AllDir:
                    this.currentShootingStyle = new AllDirShootingStyle();
                    break;
            }
        }
        protected void OnWaveStart()
        {
            isWaveStarted = true;
        }
        public void ChangeBullet(TheBullet bulletSpl)
        {
            bulletSample = bulletSpl;
        }
    }
}
