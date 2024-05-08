using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBullet : TheBullet
{
    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime * dir);
    }
}
