using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnedUtil;

public class TheBullet : MonoBehaviour, IPoolable 
{
    [SerializeField] protected float speed; 
    protected Vector2 dir;

    [SerializeField] protected float lifeTime = 1f;

    protected virtual void Start()
    {
        SetActive(true);
    }    
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move(){}
    public virtual void SetActive(bool IsActivating)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(DelayDead(lifeTime));
        //this.transform.position = this.transform.position;
    }
    public virtual void SetDir(Vector2 _dir)
    {
        dir = _dir;
    }
    protected IEnumerator DelayDead(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        this.transform.position = Vector3.zero;
        this.gameObject.SetActive(false);
    }
    public bool IsActivating() => this.gameObject.activeSelf;
}
