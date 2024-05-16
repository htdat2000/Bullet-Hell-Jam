using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class ShootingController : MonoBehaviour
    {
        protected GameObject player;
        [SerializeField] protected Shooter shoot;
        [SerializeField] protected eShootingStyleType eShootingStyleType = eShootingStyleType.Simple;

        [SerializeField] protected float shootCooldownTime = 1;
        protected float shootCooldown = 1;

        [SerializeField] protected bool chasePlayer = false;

        protected bool isWaveStarted = false;

        protected void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Event.GameEvents.OnWaveStart += OnWaveStart;
        }
        protected void Update()
        {
            if ((shootCooldown < 0) && (isWaveStarted == true))
            {
                if (chasePlayer == false)
                    ShootingConcept(Vector2.down, eShootingStyleType);
                else
                    ShootingConcept(GetPlayerDir(), eShootingStyleType);
                shootCooldown = Random.Range(1, 4);
            }
            else
            {
                shootCooldown -= Time.deltaTime;
            }
        }
        protected virtual void ShootingConcept(Vector2 _dir, eShootingStyleType _eShootingStyleType)
        {
            shoot.Shot(_dir, _eShootingStyleType);
        }
        protected void OnDisable()
        {
            Event.GameEvents.OnWaveStart -= OnWaveStart;
        }
        protected void OnWaveStart()
        {
            isWaveStarted = true;
        }
        protected Vector2 GetPlayerDir()
        {
            Vector2 playerDir = (player.transform.position - this.transform.position).normalized;
            return playerDir;
        }

    }
}