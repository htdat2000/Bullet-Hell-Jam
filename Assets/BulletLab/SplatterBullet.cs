using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterBullet : MonoBehaviour
{   
    [SerializeField] protected GameObject bullet;

    [SerializeField] protected float scalePos = 2;

    //These positions are point of x^2 + y^2 = 1 circle
    //These are 4 standard positions 
    protected Vector3[] standardPos =  
    {
        new Vector3(0, 1, 0),
        new Vector3(0, -1, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0)
    };
    //These are position of the mid point on circle between 2 standard positions 
    protected Vector3[] secondPos =
    {
        new Vector3 (Mathf.Sqrt(2)/2, Mathf.Sqrt(2)/2, 0),
        new Vector3 (-Mathf.Sqrt(2)/2, Mathf.Sqrt(2)/2, 0),
        new Vector3 (Mathf.Sqrt(2)/2, -Mathf.Sqrt(2)/2, 0),
        new Vector3 (-Mathf.Sqrt(2)/2, -Mathf.Sqrt(2)/2, 0)
    };

    protected void FixedUpdate()
    {
        
    }
    protected void TriggerBullet()
    {

    }
    protected void SpawnBulletAtStandardPos()
    {
        foreach(Vector3 pos in standardPos)
        {
            Vector3 dir = pos - this.transform.position;
            BasicBullet basicBull = Instantiate(bullet, pos * scalePos, Quaternion.identity).GetComponent<BasicBullet>();
            basicBull.SetDir(dir);
        }
    }
    protected void SpawnBulletOfSecondGroupPos()
    {
        foreach(Vector3 pos in secondPos)
        {
            Vector3 dir = pos - this.transform.position;
            BasicBullet basicBull = Instantiate(bullet, pos * scalePos, Quaternion.identity).GetComponent<BasicBullet>();
            basicBull.SetDir(dir);
        }
    }
    protected void spawnBulletOfThirdGroupPos()
    {

    }
}
