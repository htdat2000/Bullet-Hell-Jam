using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.Enemy
{   //This type of enemy will repeatedly move left and right 
    public class OscillateEnemy : EnemyBase
    {
        protected float timer = 0;

        protected override void OnDisable()
        {
            base.OnDisable();
            timer = 0;
        }
        protected override void Move()
        {
            base.Move();

            Vector3 moveDir = Mathf.Cos(timer) * moveSpeed * Time.deltaTime * Vector3.left;
            this.transform.Translate(moveDir);
            timer += Time.deltaTime;
        } 
    }
}