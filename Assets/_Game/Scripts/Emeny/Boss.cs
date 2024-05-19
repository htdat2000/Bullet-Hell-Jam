using System.Collections;
using System.Collections.Generic;
using Bullet.Manager;
using UnityEngine;
using DG.Tweening;

namespace Bullet.Enemy
{
    public class Boss : EnemyBase
    {
        public override void MoveSpawn(eAppearanceMovement eAppearanceMovement)
        {
            endPoint = new Vector2(0, 3.5f);
            base.MoveSpawn(eAppearanceMovement);
            tweener.OnComplete(() => {
                GameObject[] miniguns = GameObject.FindGameObjectsWithTag("Minigun");
                foreach(GameObject minigun in miniguns)
                {
                    minigun.GetComponent<Shooter>().Shot(Vector2.up, eShootingStyleType.Spread);
                }
            });
        }
    }
}