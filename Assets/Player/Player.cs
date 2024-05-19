using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player : MonoBehaviour
    {
        protected int life = 3;
        public Skill currentSkill = new DashSkill();

        protected void Dmg(int dmg)
        {
            life -= dmg;
            if(life <= 0)
            {
                Dead();
            }
        }
        protected void Dead()
        {
            Debug.Log("You Lose");
            Time.timeScale = 0.2f;
            SceneManager.LoadSceneAsync("GameOverScene");
        }
        protected void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Enemy"))
            {
                col.gameObject.SetActive(false);
                Dmg(1);
            }
        }
    }
}