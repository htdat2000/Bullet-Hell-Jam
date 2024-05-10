using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rb;

    [SerializeField] protected float speed = 4;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected void Update()
    {
        Move();
    }
    protected void Move()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Debug.Log(moveDir);
        rb.velocity = speed * Time.deltaTime * moveDir;
    }
}
