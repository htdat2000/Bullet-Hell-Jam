using System.Collections;
using UnityEngine;

public class YoyoBullet : TheBullet
{
    [SerializeField] protected float movingCoffient = 1f;
    protected float livingTime = 0;
    
    protected override void Update()
    {
        base.Update();
        UpdateMoveSpeed();
    }
    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime * dir);
    }
    protected virtual void UpdateMoveSpeed()
    {
        this.livingTime += Time.deltaTime;
        this.speed = movingCoffient * Mathf.Sin(livingTime);
    }
}
