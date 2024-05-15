using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] protected Shooter shoot;
        [SerializeField] protected float shootCooldownTime = 1;
        protected float shootCooldown = 1;

        protected bool isWaveStarted = false;
        
        protected void Start()
        {
            Event.GameEvents.OnWaveStart += OnWaveStart;
        }
        protected void Update()
        {
            //Shoot
            if ((shootCooldown < 0) && (isWaveStarted == true))
            {
                shoot.Shot(Vector2.down);
                shootCooldown = shootCooldownTime;
            }
            else
            {
                shootCooldown -= Time.deltaTime;
            }
        }
         protected void OnDisable()
        {
            Event.GameEvents.OnWaveStart -= OnWaveStart;
        }
        protected void OnWaveStart()
        {
            isWaveStarted = true;
        }
    }
}