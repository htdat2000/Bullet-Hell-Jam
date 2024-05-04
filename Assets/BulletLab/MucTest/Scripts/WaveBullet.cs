using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBullet : BasicBullet
{
    protected void Start()
    {
        dir = new Vector2 (1, 1);
        
    }
    protected override void Move()
    {

        transform.Translate(new Vector2 (1, 1 * Mathf.Sin(Time.time * 5)) * speed * Time.deltaTime);
    }
}
