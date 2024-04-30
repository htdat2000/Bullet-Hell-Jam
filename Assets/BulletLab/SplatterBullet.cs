using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterBullet : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;

    [SerializeField] protected float scalePos = 2;

    protected List<Vector3> posList = new();

    //These positions are point of x^2 + y^2 = 1 circle
    //These are 4 standard positions 
    protected Vector3[] standardPos =
    {
        new Vector3(0, 1, 0),
        new Vector3(0, -1, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0)
    };
    //These are position of the mid point on circle between 2 standard positions, i will call it second position
    protected Vector3[] secondPos =
    {
        new Vector3 (Mathf.Sqrt(2)/2, Mathf.Sqrt(2)/2, 0),
        new Vector3 (-Mathf.Sqrt(2)/2, Mathf.Sqrt(2)/2, 0),
        new Vector3 (Mathf.Sqrt(2)/2, -Mathf.Sqrt(2)/2, 0),
        new Vector3 (-Mathf.Sqrt(2)/2, -Mathf.Sqrt(2)/2, 0)
    };
    //These are position of the mid point on circle between standard positions and second position 
    protected Vector3[] thirdPos =
    {
        new Vector3 (0.9239f, 0.3827f),
        new Vector3 (0.9239f, -0.3827f),
        new Vector3 (-0.9239f, -0.3827f),
        new Vector3 (-0.9239f, 0.3827f),
        new Vector3 (0.3827f, 0.9239f),
        new Vector3 (-0.3827f, 0.9239f),
        new Vector3 (-0.3827f, -0.9239f),
        new Vector3 (0.3827f, -0.9239f)
    };

    protected float countdown = 0;
    protected float spawnTime = 2;

    protected void Start()
    {
        CreatePostionList();
    }
    protected void Update()
    {

        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            ShootBulletAllDirection(3);
            countdown = spawnTime;
        }
    }
    protected void ShootBulletAllDirection(int numOfPosGroup)
    {
        //NumOfPosGroup is the number of pos you want to spawn
        if (numOfPosGroup == 1)
        {
            SpawnBulletAtPosGroup(standardPos);
        }
        else if (numOfPosGroup == 2)
        {
            SpawnBulletAtPosGroup(standardPos);
            SpawnBulletAtPosGroup(secondPos);
        }
        else if(numOfPosGroup == 3)
        {
            SpawnBulletAtPosGroup(standardPos);
            SpawnBulletAtPosGroup(secondPos);
            SpawnBulletAtPosGroup(thirdPos);
        }
        else
        {
            SpawnBulletAtPosGroup(standardPos);
        }
    }
    protected void SpawnBulletAtPosGroup(Vector3[] spawnPosGroup)
    {
        foreach (Vector3 pos in spawnPosGroup)
        {
            Spawn(pos);
        }
    }
    protected void SpawnBulletAtRandomPos()
    {
        int maxIndex = posList.Count;
        Spawn(posList[Random.Range(0, maxIndex)]);
    }
    protected void Spawn(Vector3 pos)
    {
        Vector3 spawnPos = this.transform.position + (pos * scalePos);
        Vector3 dir = pos - this.transform.position;
        BasicBullet basicBull = Instantiate(bullet, spawnPos, Quaternion.identity).GetComponent<BasicBullet>();
        basicBull.SetDir(dir); 
    }
    protected void CreatePostionList()
    {
        posList.AddRange(standardPos);
        posList.AddRange(secondPos);
        posList.AddRange(thirdPos);
        //SortPosList(); 
        //Is finding way to sort
    }
    protected void SortPosList()
    {
        posList.Sort((x, y) =>
        {
            if (x.x == y.x)
            {
                return x.y.CompareTo(y.y);
            }
            else
            {
                return x.x.CompareTo(y.x);
            }
        });

        foreach (var i in posList)
        {
            Debug.Log(i);
        }
    }
}
