using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingYoyoBullet : YoyoBullet
{
    [SerializeField] private float movingValue;
    [SerializeField] private bool clockwise;
    [SerializeField] private float movingSpeed;
    protected Vector2 normalVector;
    protected Vector2 transitionVector;
    public override void SetDir(Vector2 _dir)
    {
        base.SetDir(_dir);
        this.normalVector = new Vector2(_dir.y * (this.clockwise ? 1 : -1) , _dir.x  * (this.clockwise ? -1 : 1)).normalized;
    }
    protected override void Move()
    {
        _();
        transform.Translate(speed * Time.deltaTime * (dir) + (movingSpeed * Time.deltaTime * normalVector));
    }
    protected override void UpdateMoveSpeed()
    {
        this.livingTime += Time.deltaTime;
        this.speed = movingCoffient * Mathf.Sin(livingTime);
    }
    protected void _()
    {
        movingSpeed = movingCoffient * Mathf.Cos(livingTime);
    }
    // protected override void UpdateMoveSpeed()
    // {
    //     // normalVector = 
    //     transitionVector = Mathf.Sin(livingTime) * normalVector;
    // }
}
