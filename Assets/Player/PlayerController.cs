using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected Player player;

    [SerializeField] protected float speed = 4;
    [SerializeField] protected float dashSpeed = 2;

    protected Vector3 moveDir = Vector3.zero;

    protected void Update()
    {
        SkillTrigger();
    }
    protected void FixedUpdate()
    {
        Move();
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
        }
    }
}
