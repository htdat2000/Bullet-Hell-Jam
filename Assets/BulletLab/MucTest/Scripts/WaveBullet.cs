using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBullet : TheBullet
{
    protected float timer = 0;

    protected override void Update()
    {
        Move();
    }
    protected virtual void OnDisable()
    {
        timer = 0;
    }
    protected override void Move()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        transform.Translate(new Vector2 (- dir.y, dir.x) * Mathf.Cos(timer*5) * speed * Time.deltaTime);
        timer += Time.deltaTime;
    }
}
