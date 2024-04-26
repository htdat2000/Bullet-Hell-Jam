using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    [SerializeField] protected float speed; 
    protected Vector3 dir;

    protected void Update()
    {
        Move();
    }
    protected void Move()
    {
        transform.Translate(speed * Time.deltaTime * dir);
    }
    public void SetDir(Vector3 _dir)
    {
        dir = _dir;
    }
}
