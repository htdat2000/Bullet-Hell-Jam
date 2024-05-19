using Bullet.Manager;
using DG.Tweening;
using UnityEngine;
using Event;

namespace Bullet.Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected int defaultHP = 3;
        protected int hp = 3;

        protected Vector3 originPosition; //this is the position that the enemy stay when it is spawned
        protected Vector2 endPoint;
        protected Tweener tweener;

        protected bool isWaveStarted = false;

        [SerializeField] protected float moveSpeed = 2;

        protected virtual void OnEnable()
        {
            hp = defaultHP;
        }
        protected virtual void Start()
        {
            GameEvents.OnWaveStart += OnWaveStart;
        }
        protected virtual void Update()
        {
            if(isWaveStarted == false)
            {
                return;
            }
            Move();
        }
        protected virtual void OnDisable()
        {
            isWaveStarted = false;
            GameEvents.OnWaveStart -= OnWaveStart;
        }
        //This is how enemy moves into the screen
        public virtual void MoveSpawn(eAppearanceMovement eAppearanceMovement)
        {
            if(tweener != null)
            {
                tweener.Kill();
            }

            //Raining drop movement
            tweener = this.transform.DOMove(endPoint, 0.5f);
            this.transform.position = this.endPoint + Vector2.up * 10f; 
            tweener.Play().OnComplete(() => {originPosition = this.transform.position;});
        }
        public void SetStartPoint(Vector2 startPoint)
        {
            this.transform.position = startPoint;
        }
        public void SetEndPoint(Vector2 endPoint)
        {
            this.endPoint = endPoint;
        }
        protected virtual void Move()
        {
            if(tweener != null)
            {
                tweener.Kill();
            }
        }
        protected void TakeDmg(int _dmg)
        {
            hp -= _dmg;
            if(hp <= 0)
            {
                GameEvents.OnEnemyDefeated?.Invoke();
                this.gameObject.SetActive(false);
            }
        }
        protected virtual void OnWaveStart()
        {
            isWaveStarted = true;
        }
        protected void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Bullet"))
            {
                col.gameObject.SetActive(false);
                TakeDmg(1);
            }
        }
    }
}
