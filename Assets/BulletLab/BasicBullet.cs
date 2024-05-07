using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    [SerializeField] protected float speed; 
    protected Vector2 dir;

    protected virtual void Update()
    {

        Move();
    }
    protected virtual void Move()
    {
        transform.Translate(speed * Time.deltaTime * dir);
    }
    public virtual void SetActive(bool IsActivating)
    {
        this.gameObject.SetActive(true);
        this.transform.position = this.transform.position;
    }
    public virtual void SetDir(Vector2 _dir)
    {
        dir = _dir;
    }
}
