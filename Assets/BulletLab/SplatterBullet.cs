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

    protected float countdown = 0;
    protected float spawnTime = 2;

    protected void Start()
    {
        
    }
    protected void Update()
    {
        
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        } 
        else
        {
            SpawnBulletAtRandomPos();
            countdown = spawnTime;
        }
    }
    protected void ShootBulletAllDirection(int numOfPosGroup) 
    {   
        //NumOfPosGroup is the number of pos you want to spawn
        if(numOfPosGroup == 1)
        {
            SpawnBulletAtPosGroup(standardPos);
        }
        else if(numOfPosGroup == 2)
        {
            SpawnBulletAtPosGroup(standardPos);
            SpawnBulletAtPosGroup(secondPos);
        }
        else
        {
            SpawnBulletAtPosGroup(standardPos);
        }
    }
    protected void SpawnBulletAtPosGroup(Vector3[] spawnPosGroup)
    {
        foreach(Vector3 pos in spawnPosGroup)
        {
            Spawn(pos);
        }
    }
    protected void SpawnBulletAtRandomPos()
    {
        List<Vector3> tempList = new List<Vector3>();
        tempList.AddRange(standardPos);
        tempList.AddRange(secondPos);
        
        int maxIndex = tempList.Count;
        Spawn(tempList[Random.Range(0, maxIndex)]);
    }
    protected void Spawn(Vector3 pos)
    {
        Vector3 spawnPos = this.transform.position + (pos * scalePos);
            Vector3 dir = pos - this.transform.position;
            BasicBullet basicBull = Instantiate(bullet, spawnPos, Quaternion.identity).GetComponent<BasicBullet>();
            basicBull.SetDir(dir);
    }
}
