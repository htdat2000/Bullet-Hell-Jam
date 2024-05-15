using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] protected Player player;

        [SerializeField] protected float speed = 4;

        protected Vector3 moveDir = Vector3.zero;

        protected float skillCooldownTime = 3;
        protected float skillCooldown = 0;

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
                shoot.Shot(Vector2.up);
                shootCooldown = shootCooldownTime;
            }
            else
            {
                shootCooldown -= Time.deltaTime;
            }

            //Skill
            if (skillCooldown < 0)
            {
                SkillTrigger();
            }
            else
            {
                skillCooldown -= Time.deltaTime;
            }
        }
        protected void FixedUpdate()
        {
            Move();
        }
        protected void OnDisable()
        {
            Event.GameEvents.OnWaveStart -= OnWaveStart;
        }
        protected void Move()
        {
            moveDir = Vector3.zero;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDir += Vector3.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDir += Vector3.left;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDir += Vector3.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDir += Vector3.down;
            }
            this.transform.position += speed * Time.fixedDeltaTime * moveDir.normalized;
        }
        protected void SkillTrigger()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (player.currentSkill == null)
                {
                    return;
                }
                player.currentSkill.Trigger(player.gameObject, moveDir);
                skillCooldown = skillCooldownTime;
            }
        }
        protected void OnWaveStart()
        {
            isWaveStarted = true;
        }
    }
}