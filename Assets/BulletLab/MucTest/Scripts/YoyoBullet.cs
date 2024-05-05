using System.Collections;
using EnedUtil;
using UnityEngine;

public class YoyoBullet : BasicBullet, IPoolable
{
    [SerializeField] protected float lifeTime = 1f;
    [SerializeField] protected float movingCoffient = 1f;
    protected float livingTime = 0;
    protected virtual void Start()
    {
        SetActive(true);
    }
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

    public override void SetActive(bool IsActivating)
    {
        base.SetActive(IsActivating);
        StartCoroutine(DelayDead(lifeTime));
    }

    private IEnumerator DelayDead(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        this.transform.position = Vector3.zero;
        this.gameObject.SetActive(false);
    }
    public bool IsActivating() => this.gameObject.activeSelf;
}
