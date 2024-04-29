using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnedUtil;

public class MucTheBullet : BasicBullet, IPoolable
{
    [SerializeField] private float lifeTime = 1f;
    private void Start()
    {
        SetActive(true);
    }

    public void SetActive(bool IsActivating)
    {
        this.gameObject.SetActive(true);
        this.transform.position = this.transform.position;
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
