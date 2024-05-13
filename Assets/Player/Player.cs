using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        protected int life = 3;
        public Skill currentSkill = new DashSkill();
    }
}